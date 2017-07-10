--
-- PostgreSQL database dump
--

-- Dumped from database version 9.6.2
-- Dumped by pg_dump version 9.6.0

-- Started on 2017-07-01 13:14:23

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 14 (class 2615 OID 16402)
-- Name: inkaart; Type: SCHEMA; Schema: -; Owner: postgres
--

DROP SCHEMA inkaart CASCADE;
CREATE SCHEMA inkaart;


ALTER SCHEMA inkaart OWNER TO postgres;

--
-- TOC entry 1 (class 3079 OID 12387)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2652 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = inkaart, pg_catalog;

--
-- TOC entry 309 (class 1255 OID 17646)
-- Name: getidlote(); Type: FUNCTION; Schema: inkaart; Owner: admin
--

CREATE FUNCTION getidlote() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
DECLARE
  max_id_lote integer;
BEGIN
  -- Buscar si ya existe el valor de id_lote
  SELECT MAX(id_lote) INTO max_id_lote FROM inkaart."RatioPerDay" WHERE date = NEW.date;
  -- Si es nulo, se generará uno nuevo
  IF (max_id_lote IS NULL) THEN
    SELECT MAX(id_lote) INTO max_id_lote FROM inkaart."RatioPerDay";
    IF (max_id_lote IS NULL) THEN
      max_id_lote = 1;
    ELSE
      max_id_lote = max_id_lote + 1;
    END IF;
  END IF;
  -- Actualizar la fila para colocar el id_lote
  UPDATE inkaart."RatioPerDay" SET id_lote = max_id_lote WHERE id_ratioperday = NEW.id_ratioperday;
  -- Devolver el trigger
  RETURN NEW;
END;    
$$;


ALTER FUNCTION inkaart.getidlote()

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 286 (class 1259 OID 17737)
-- Name: Assignment; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Assignment" (
    id_assignment integer NOT NULL,
    id_simulation integer NOT NULL,
    date date NOT NULL,
    objective_function_value double precision NOT NULL,
    tabu_iterations integer NOT NULL,
    assigned_workers integer NOT NULL,
    huacos_produced integer NOT NULL,
    huamanga_produced integer NOT NULL,
    altarpiece_produced integer NOT NULL
);


CREATE TABLE "AssignmentLine" (
    id_assignment_line integer NOT NULL,
    id_assignment integer NOT NULL,
    id_worker integer NOT NULL,
    id_job integer NOT NULL,
    id_recipe integer NOT NULL,
    produced integer NOT NULL,
    miniturn_start integer NOT NULL,
    miniturns_used integer NOT NULL
);

CREATE SEQUENCE "Assignment_id_assignment_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Assignment_id_assignment_seq" OWNED BY "AssignmentLine".id_assignment_line;


--
-- TOC entry 285 (class 1259 OID 17735)
-- Name: Assignment_id_assignment_seq1; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE "Assignment_id_assignment_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Assignment_id_assignment_seq1" OWNED BY "Assignment".id_assignment;


--
-- TOC entry 213 (class 1259 OID 16590)
-- Name: Client; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Client" (
    "idClient" integer DEFAULT nextval(('inkaart.cliente_idcliente_seq'::text)::regclass) NOT NULL,
    "clientType" integer NOT NULL,
    name text NOT NULL,
    ruc bigint NOT NULL,
    dni bigint NOT NULL,
    priority integer NOT NULL,
    type integer NOT NULL,
    status integer NOT NULL,
    address text NOT NULL,
    phone bigint,
    "contactName" text NOT NULL,
    email text
);

CREATE TABLE "DocumentType" (
    "idTipoDocumento" integer DEFAULT nextval(('inkaart.tipodocumento_idtipodocumento_seq'::text)::regclass) NOT NULL,
    nombre text NOT NULL,
    descripcion text
);

CREATE TABLE "Index" (
    id_index integer NOT NULL,
    id_worker integer NOT NULL,
    id_job integer NOT NULL,
    id_recipe integer NOT NULL,
    average_breakage double precision NOT NULL,
    average_time double precision NOT NULL,
    status boolean DEFAULT true NOT NULL
);

CREATE SEQUENCE "Index_idIndex_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Index_idIndex_seq" OWNED BY "Index".id_index;


--
-- TOC entry 287 (class 1259 OID 17778)
-- Name: Line-Document; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Line-Document" (
    "idLineItem" integer,
    finished integer,
    pu real,
    "idSaleDocument" integer,
    "idLineDocument" integer NOT NULL
);


CREATE SEQUENCE "Line-Document_idLineDocument_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Line-Document_idLineDocument_seq" OWNED BY "Line-Document"."idLineDocument";


--
-- TOC entry 212 (class 1259 OID 16582)
-- Name: LineItem; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "LineItem" (
    "idLineItem" integer DEFAULT nextval(('inkaart.lineapedido_idlineapedido_seq'::text)::regclass) NOT NULL,
    quantity integer NOT NULL,
    quality text NOT NULL,
    "idRecipe" integer NOT NULL,
    "idProduct" integer NOT NULL,
    "idOrder" integer,
    "lineStatus" text,
    "quantityProduced" integer,
    "quantityInvoiced" integer
);

CREATE TABLE "RawMaterial" (
    id_raw_material integer NOT NULL,
    name text NOT NULL,
    description text,
    unit text NOT NULL,
    status text NOT NULL,
    average_price real
);


ALTER TABLE "RawMaterial" OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 16504)
-- Name: MateriaPrima_idMateria_seq; Type: SEQUENCE; Schema: inkaart; Owner: postgres
--

CREATE SEQUENCE "MateriaPrima_idMateria_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "MateriaPrima_idMateria_seq" OWNER TO postgres;

--
-- TOC entry 2657 (class 0 OID 0)
-- Dependencies: 205
-- Name: MateriaPrima_idMateria_seq; Type: SEQUENCE OWNED BY; Schema: inkaart; Owner: postgres
--

ALTER SEQUENCE "MateriaPrima_idMateria_seq" OWNED BY "RawMaterial".id_raw_material;


--
-- TOC entry 258 (class 1259 OID 17074)
-- Name: Movement; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Movement" (
    "idMovement" integer NOT NULL,
    "idNote" integer,
    "idBill" integer,
    "idMovementType" integer,
    "idWarehouse" integer,
    "idMovementReason" integer,
    "dateIn" date DEFAULT ('now'::text)::date,
    "idWarehouseDestiny" integer,
    status integer DEFAULT 1,
    "idDocumentType" integer,
    "idItem" integer,
    "itemType" integer,
    quantity integer
);

COMMENT ON COLUMN "Movement"."idWarehouseDestiny" IS 'Alamacen de destino para los movimientos entrada/salida';


--
-- TOC entry 2659 (class 0 OID 0)
-- Dependencies: 258
-- Name: COLUMN "Movement".status; Type: COMMENT; Schema: inkaart; Owner: admin
--

COMMENT ON COLUMN "Movement".status IS 'Eliminado o no
0: Inactivo
1: Activo';


--
-- TOC entry 2660 (class 0 OID 0)
-- Dependencies: 258
-- Name: COLUMN "Movement"."idDocumentType"; Type: COMMENT; Schema: inkaart; Owner: admin
--

COMMENT ON COLUMN "Movement"."idDocumentType" IS 'FK de DocumentType';


--
-- TOC entry 2661 (class 0 OID 0)
-- Dependencies: 258
-- Name: COLUMN "Movement"."idItem"; Type: COMMENT; Schema: inkaart; Owner: admin
--

COMMENT ON COLUMN "Movement"."idItem" IS 'es el id del producto o id de materia prima, dependiendo de itemType';


--
-- TOC entry 2662 (class 0 OID 0)
-- Dependencies: 258
-- Name: COLUMN "Movement"."itemType"; Type: COMMENT; Schema: inkaart; Owner: admin
--

COMMENT ON COLUMN "Movement"."itemType" IS '0 es MP, 1 es P';


--
-- TOC entry 233 (class 1259 OID 16783)
-- Name: MovementName; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "MovementName" (
    "idMovName" integer NOT NULL,
    description text
);


CREATE SEQUENCE "MovementName_idMovName_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;



ALTER SEQUENCE "MovementName_idMovName_seq" OWNED BY "MovementName"."idMovName";


--
-- TOC entry 235 (class 1259 OID 16791)
-- Name: MovementType; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "MovementType" (
    "idMovementType" integer NOT NULL,
    description text
);


CREATE SEQUENCE "MovementType_idMovementType_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;



ALTER SEQUENCE "MovementType_idMovementType_seq" OWNED BY "MovementType"."idMovementType";


--
-- TOC entry 257 (class 1259 OID 17072)
-- Name: Movement_idMovement_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE "Movement_idMovement_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;



ALTER SEQUENCE "Movement_idMovement_seq" OWNED BY "Movement"."idMovement";


--
-- TOC entry 256 (class 1259 OID 17047)
-- Name: NoteDetail; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "NoteDetail" (
    "idNote" integer NOT NULL,
    description text,
    "idNoteType" integer,
    "idDateIn" date,
    "idBill" integer,
    "idReturn" integer
);


CREATE SEQUENCE "NoteDetail_idNote_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;



ALTER SEQUENCE "NoteDetail_idNote_seq" OWNED BY "NoteDetail"."idNote";


--
-- TOC entry 231 (class 1259 OID 16772)
-- Name: NoteType; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "NoteType" (
    "idNoteType" integer NOT NULL,
    description text
);


CREATE SEQUENCE "NoteType_idNoteType_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "NoteType_idNoteType_seq" OWNED BY "NoteType"."idNoteType";


--
-- TOC entry 210 (class 1259 OID 16547)
-- Name: PurcharseOrder; Type: TABLE; Schema: inkaart; Owner: postgres
--

CREATE TABLE "PurcharseOrder" (
    id_order integer NOT NULL,
    id_supplier integer,
    status text,
    creation_date date,
    delivery_date date,
    total real
);


CREATE SEQUENCE "OrdenCompra_idOrden_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;



ALTER SEQUENCE "OrdenCompra_idOrden_seq" OWNED BY "PurcharseOrder".id_order;


--
-- TOC entry 251 (class 1259 OID 16960)
-- Name: Order; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Order" (
    "idOrder" integer NOT NULL,
    "idClient" integer,
    "deliveryDate" date NOT NULL,
    "saleAmount" real NOT NULL,
    igv real NOT NULL,
    "totalAmount" real NOT NULL,
    "orderStatus" text NOT NULL,
    "bdStatus" integer NOT NULL,
    type text,
    reason text,
    totaldev real
);


CREATE SEQUENCE "Order_idOrder_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;



ALTER SEQUENCE "Order_idOrder_seq" OWNED BY "Order"."idOrder";


--
-- TOC entry 198 (class 1259 OID 16450)
-- Name: Worker; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Worker" (
    id_worker integer NOT NULL,
    first_name text,
    last_name text,
    dni integer,
    turn integer,
    id_user integer,
    phone integer,
    address text,
    email text
);


CREATE SEQUENCE "Person_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;



ALTER SEQUENCE "Person_id_seq" OWNED BY "Worker".id_worker;


--
-- TOC entry 221 (class 1259 OID 16637)
-- Name: Process; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Process" (
    id_process integer NOT NULL,
    description text,
    number_of_jobs integer
);


COMMENT ON COLUMN "Process".number_of_jobs IS 'Numero de puestos de trabajo disponibles para el proceso';


--
-- TOC entry 229 (class 1259 OID 16749)
-- Name: Process-Product; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Process-Product" (
    "idProduct" integer NOT NULL,
    "idProcess" integer NOT NULL,
    "idJob" integer NOT NULL,
    name text NOT NULL,
    "order" integer
);


COMMENT ON COLUMN "Process-Product"."order" IS 'El orden de cada puesto de trabajo según cada producto';


--
-- TOC entry 261 (class 1259 OID 17148)
-- Name: Process-Product_idJob_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE "Process-Product_idJob_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Process-Product_idJob_seq" OWNED BY "Process-Product"."idJob";


--
-- TOC entry 220 (class 1259 OID 16635)
-- Name: Process_idProcess_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE "Process_idProcess_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Process_idProcess_seq" OWNED BY "Process".id_process;


--
-- TOC entry 225 (class 1259 OID 16671)
-- Name: Product; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Product" (
    "idProduct" integer NOT NULL,
    "idProductType" integer,
    name text NOT NULL,
    description text,
    "localPrice" real,
    "basePrice" real,
    "exportPrice" real,
    "actualStock" integer,
    "logicalStock" integer,
    status integer NOT NULL
);


CREATE TABLE "Product-Warehouse" (
    "idProduct" integer,
    "idWarehouse" integer,
    "currentStock" integer,
    "virtualStock" integer,
    "minimunStock" integer,
    state text,
    "maximunStock" integer,
    "idProductWarehouse" integer NOT NULL,
    "stateItem" integer,
    breaks integer
);



CREATE SEQUENCE "Product-Warehouse_idProductWarehouse_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Product-Warehouse_idProductWarehouse_seq" OWNED BY "Product-Warehouse"."idProductWarehouse";


--
-- TOC entry 223 (class 1259 OID 16649)
-- Name: ProductType; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "ProductType" (
    "idProductType" integer NOT NULL,
    name text,
    description text
);

CREATE SEQUENCE "ProductType_idProductType_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;



ALTER SEQUENCE "ProductType_idProductType_seq" OWNED BY "ProductType"."idProductType";


--
-- TOC entry 224 (class 1259 OID 16669)
-- Name: Product_idProduct_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE "Product_idProduct_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Product_idProduct_seq" OWNED BY "Product"."idProduct";


--
-- TOC entry 208 (class 1259 OID 16517)
-- Name: Supplier; Type: TABLE; Schema: inkaart; Owner: postgres
--

CREATE TABLE "Supplier" (
    id_supplier integer NOT NULL,
    name text NOT NULL,
    ruc text NOT NULL,
    contact text,
    telephone integer,
    email text,
    status text,
    address text,
    priority integer
);


CREATE SEQUENCE "Proveedor_idProveedor_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Proveedor_idProveedor_seq" OWNED BY "Supplier".id_supplier;


--
-- TOC entry 290 (class 1259 OID 17821)
-- Name: PurchaseDocument; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "PurchaseDocument" (
    id_purchase_document integer NOT NULL,
    id_purchase_order integer NOT NULL,
    factura integer NOT NULL,
    id_supplier integer NOT NULL,
    total real NOT NULL,
    delivery_date date NOT NULL
);



CREATE TABLE "PurchaseDocumentLine" (
    id_purchase_order integer,
    factura integer,
    id_supplier integer,
    id_line_purchase_doc integer NOT NULL,
    amount real NOT NULL,
    igv real NOT NULL,
    total_line real NOT NULL
)
INHERITS ("PurchaseDocument");



CREATE SEQUENCE "PurchaseDocumentLine_id_line_purchase_doc_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;



ALTER SEQUENCE "PurchaseDocumentLine_id_line_purchase_doc_seq" OWNED BY "PurchaseDocumentLine".id_line_purchase_doc;


--
-- TOC entry 289 (class 1259 OID 17819)
-- Name: PurchaseDocument_id_purchase_document_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE "PurchaseDocument_id_purchase_document_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "PurchaseDocument_id_purchase_document_seq" OWNED BY "PurchaseDocument".id_purchase_document;


--
-- TOC entry 264 (class 1259 OID 17400)
-- Name: PurchaseOrderDetail; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "PurchaseOrderDetail" (
    id_order integer NOT NULL,
    id_raw_material integer NOT NULL,
    id_suppliers integer NOT NULL,
    quantity integer NOT NULL,
    amount real NOT NULL,
    id_detail integer NOT NULL,
    id_factura integer,
    status text NOT NULL,
    igv real NOT NULL
);


CREATE SEQUENCE "PurchaseOrderDetail_id_detail_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;



ALTER SEQUENCE "PurchaseOrderDetail_id_detail_seq" OWNED BY "PurchaseOrderDetail".id_detail;


--
-- TOC entry 269 (class 1259 OID 17513)
-- Name: Ratio; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Ratio" (
    id_ratio integer NOT NULL,
    date date NOT NULL,
    id_worker integer NOT NULL,
    id_job integer NOT NULL,
    id_recipe integer NOT NULL,
    start_time time(0) without time zone NOT NULL,
    end_time time(0) without time zone NOT NULL,
    broken integer NOT NULL,
    produced integer NOT NULL,
    breakage double precision NOT NULL,
    "time" double precision NOT NULL,
    status boolean DEFAULT true NOT NULL
);



COMMENT ON COLUMN "Ratio".id_job IS 'El índice del puesto de trabajo (producto x proceso) al que fue asignado el trabajador en el turno.';


--
-- TOC entry 2683 (class 0 OID 0)
-- Dependencies: 269
-- Name: COLUMN "Ratio"."time"; Type: COMMENT; Schema: inkaart; Owner: admin
--

COMMENT ON COLUMN "Ratio"."time" IS 'Tiempo promedio (en minutos) que le toma al trabajador realizar la receta del producto del puesto de trabajo que se le asignó.';


--
-- TOC entry 2684 (class 0 OID 0)
-- Dependencies: 269
-- Name: COLUMN "Ratio".status; Type: COMMENT; Schema: inkaart; Owner: admin
--

COMMENT ON COLUMN "Ratio".status IS 'Verdadero si la fila está activa, falso si se le ha realizado a la fila un soft deletion.';


--
-- TOC entry 273 (class 1259 OID 17563)
-- Name: RatioPerDay; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "RatioPerDay" (
    id_ratioperday integer NOT NULL,
    date date NOT NULL,
    id_product integer NOT NULL,
    produced integer NOT NULL,
    id_lote integer
);



COMMENT ON COLUMN "RatioPerDay".id_ratioperday IS 'La llave primaria (ID) de la tabla RatioPerDay.';


--
-- TOC entry 2686 (class 0 OID 0)
-- Dependencies: 273
-- Name: COLUMN "RatioPerDay".date; Type: COMMENT; Schema: inkaart; Owner: admin
--

COMMENT ON COLUMN "RatioPerDay".date IS 'El día laboral al que hace mención cada registro.';


--
-- TOC entry 2687 (class 0 OID 0)
-- Dependencies: 273
-- Name: COLUMN "RatioPerDay".id_product; Type: COMMENT; Schema: inkaart; Owner: admin
--

COMMENT ON COLUMN "RatioPerDay".id_product IS 'ID del producto realizado en el día descrito por "date".';


--
-- TOC entry 2688 (class 0 OID 0)
-- Dependencies: 273
-- Name: COLUMN "RatioPerDay".produced; Type: COMMENT; Schema: inkaart; Owner: admin
--

COMMENT ON COLUMN "RatioPerDay".produced IS 'Cantidad producida del producto descrito en "id_product".';


--
-- TOC entry 272 (class 1259 OID 17561)
-- Name: RatioPerDay_id_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE "RatioPerDay_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;

ALTER SEQUENCE "RatioPerDay_id_seq" OWNED BY "RatioPerDay".id_ratioperday;


--
-- TOC entry 268 (class 1259 OID 17511)
-- Name: Ratio_idRatio_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE "Ratio_idRatio_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Ratio_idRatio_seq" OWNED BY "Ratio".id_ratio;


--
-- TOC entry 262 (class 1259 OID 17340)
-- Name: RawMaterial-Supplier; Type: TABLE; Schema: inkaart; Owner: postgres
--

CREATE TABLE "RawMaterial-Supplier" (
    id_raw_material integer NOT NULL,
    id_supplier integer NOT NULL,
    price real,
    id_rawmaterial_supplier integer NOT NULL,
    status text NOT NULL
);


CREATE SEQUENCE "RawMaterial-Supplier_id_rawmaterial_supplier_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "RawMaterial-Supplier_id_rawmaterial_supplier_seq" OWNED BY "RawMaterial-Supplier".id_rawmaterial_supplier;


--
-- TOC entry 248 (class 1259 OID 16915)
-- Name: RawMaterial-Warehouse; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "RawMaterial-Warehouse" (
    "idWarehouse" integer,
    "idRawMaterial" integer,
    "currentStock" integer,
    "virtualStock" integer,
    "minimunStock" integer,
    state text,
    "maximunStock" integer,
    "idRawMaterialWarehouse" integer NOT NULL
);


CREATE SEQUENCE "RawMaterial-Warehouse_idRawMaterialWarehouse_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "RawMaterial-Warehouse_idRawMaterialWarehouse_seq" OWNED BY "RawMaterial-Warehouse"."idRawMaterialWarehouse";


--
-- TOC entry 204 (class 1259 OID 16495)
-- Name: Recipe; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Recipe" (
    "idRecipe" integer NOT NULL,
    description text,
    version text NOT NULL,
    status integer NOT NULL,
    "idProduct" integer
);

CREATE TABLE "Recipe-RawMaterial" (
    "idRecipe" integer,
    "idRawMaterial" integer,
    "materialCount" integer,
    status text
);


CREATE TABLE "Return" (
    "idReturn" integer DEFAULT nextval(('inkaart.devolucion_iddevolucion_seq'::text)::regclass) NOT NULL,
    "issueDate" date NOT NULL,
    "returnAmount" real NOT NULL,
    igv real NOT NULL,
    total real NOT NULL,
    "idSalesDocument" integer NOT NULL,
    "idLineItem" integer NOT NULL,
    "idClient" integer NOT NULL,
    reason text NOT NULL
);


CREATE TABLE "Role" (
    id_role integer NOT NULL,
    description text,
    security_general_parameters boolean,
    security_user_list boolean,
    security_roles boolean,
    purchases_suppliers boolean,
    purchases_raw_materials boolean,
    purchases_unit_of_measure boolean,
    purchases_purchase_order boolean,
    production_final_product boolean,
    production_production_process boolean,
    production_production_turn boolean,
    production_worker_assignment boolean,
    production_turn_report boolean,
    production_productivity_report boolean,
    sales_clients boolean,
    sales_orders boolean,
    sales_generate_report boolean,
    warehouse_warehouses boolean,
    warehouse_movements boolean,
    warehouse_stock_reports boolean,
    warehouse_kardex_reports boolean
);


CREATE SEQUENCE "Role_idRole_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Role_idRole_seq" OWNED BY "Role".id_role;


--
-- TOC entry 245 (class 1259 OID 16864)
-- Name: SalesDocument; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "SalesDocument" (
    "idSalesDocument" integer NOT NULL,
    "idDocumentType" integer,
    amount real,
    igv real,
    "totalAmount" real,
    "idOrder" integer
);


CREATE SEQUENCE "SalesDocument_idSalesDocument_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;



ALTER SEQUENCE "SalesDocument_idSalesDocument_seq" OWNED BY "SalesDocument"."idSalesDocument";


--
-- TOC entry 282 (class 1259 OID 17681)
-- Name: Simulation; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Simulation" (
    id_simulation integer NOT NULL,
    name text NOT NULL,
    start_date date NOT NULL,
    end_date date NOT NULL,
    number_of_days integer NOT NULL,
    breakage_weight real NOT NULL,
    time_weight real NOT NULL,
    huaco_weight real NOT NULL,
    huamanga_weight real NOT NULL,
    altarpiece_weight real NOT NULL,
    created_at date DEFAULT ('now'::text)::date,
    status boolean DEFAULT true NOT NULL
);


COMMENT ON COLUMN "Simulation".name IS 'Nombre dado a la simulación';


--
-- TOC entry 2696 (class 0 OID 0)
-- Dependencies: 282
-- Name: COLUMN "Simulation".limit_time; Type: COMMENT; Schema: inkaart; Owner: admin
--

--
-- TOC entry 2698 (class 0 OID 0)
-- Dependencies: 282
-- Name: COLUMN "Simulation".status; Type: COMMENT; Schema: inkaart; Owner: admin
--

COMMENT ON COLUMN "Simulation".status IS 'true - Activo
false - Inactivo';


--
-- TOC entry 296 (class 1259 OID 17897)
-- Name: Simulation-Order; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Simulation-Order" (
    id_simulation_order integer NOT NULL,
    id_simulation integer NOT NULL,
    id_order integer NOT NULL
);
ALTER TABLE ONLY "Simulation-Order" ALTER COLUMN id_simulation SET STATISTICS 0;
ALTER TABLE ONLY "Simulation-Order" ALTER COLUMN id_order SET STATISTICS 0;


CREATE SEQUENCE "Simulation-Order_id_simulation_order_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Simulation-Order_id_simulation_order_seq" OWNED BY "Simulation-Order".id_simulation_order;


--
-- TOC entry 294 (class 1259 OID 17874)
-- Name: Simulation-Worker; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Simulation-Worker" (
    id_simulation_worker integer NOT NULL,
    id_simulation integer NOT NULL,
    id_worker integer NOT NULL
);
ALTER TABLE ONLY "Simulation-Worker" ALTER COLUMN id_worker SET STATISTICS 0;


CREATE SEQUENCE "Simulation-Worker_id_simulation_worker_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Simulation-Worker_id_simulation_worker_seq" OWNED BY "Simulation-Worker".id_simulation_worker;


--
-- TOC entry 281 (class 1259 OID 17679)
-- Name: Simulation_id_simulation_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE "Simulation_id_simulation_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Simulation_id_simulation_seq" OWNED BY "Simulation".id_simulation;


--
-- TOC entry 276 (class 1259 OID 17615)
-- Name: StockDocument; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "StockDocument" (
    id integer NOT NULL,
    "idDocument" integer,
    "documentType" text,
    product_id integer,
    product_stock integer,
    fecha date,
    product_type text,
    vez integer DEFAULT 0
);


CREATE TABLE "TabuParameters" (
    list_length integer NOT NULL,
    list_growth real NOT NULL,
    max_no_growth integer NOT NULL,
    max_iterations integer NOT NULL,
    neighbor_checks integer NOT NULL
);


COMMENT ON COLUMN "TabuParameters".list_length IS 'Largo inicial de la lista tabu';


--
-- TOC entry 2703 (class 0 OID 0)
-- Dependencies: 263
-- Name: COLUMN "TabuParameters".list_growth; Type: COMMENT; Schema: inkaart; Owner: admin
--

COMMENT ON COLUMN "TabuParameters".list_growth IS 'Factor de crecimiento de la lista tabu';


--
-- TOC entry 2704 (class 0 OID 0)
-- Dependencies: 263
-- Name: COLUMN "TabuParameters".max_no_growth; Type: COMMENT; Schema: inkaart; Owner: admin
--

COMMENT ON COLUMN "TabuParameters".max_no_growth IS 'Maxima cantidad de iteraciones sin que la lista crezca';


--
-- TOC entry 2705 (class 0 OID 0)
-- Dependencies: 263
-- Name: COLUMN "TabuParameters".max_iterations; Type: COMMENT; Schema: inkaart; Owner: admin
--

COMMENT ON COLUMN "TabuParameters".max_iterations IS 'Maxima cantidad de iteraciones';


--
-- TOC entry 2706 (class 0 OID 0)
-- Dependencies: 263
-- Name: COLUMN "TabuParameters".neighbor_checks; Type: COMMENT; Schema: inkaart; Owner: admin
--

COMMENT ON COLUMN "TabuParameters".neighbor_checks IS 'Maxima cantidad de vecinos a revisar';


--
-- TOC entry 200 (class 1259 OID 16463)
-- Name: Turn; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Turn" (
    "idTurn" integer NOT NULL,
    start time(0) without time zone,
    "end" time(0) without time zone,
    description text
);


CREATE TABLE "Turn-Worker" (
    "idTurn" integer NOT NULL,
    "idReport" integer NOT NULL,
    "idWorker" integer NOT NULL
);


CREATE SEQUENCE "Turn-Worker_idReport_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Turn-Worker_idReport_seq" OWNED BY "Turn-Worker"."idReport";


--
-- TOC entry 238 (class 1259 OID 16819)
-- Name: Turn-Worker_idTurn_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE "Turn-Worker_idTurn_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Turn-Worker_idTurn_seq" OWNED BY "Turn-Worker"."idTurn";


--
-- TOC entry 240 (class 1259 OID 16823)
-- Name: Turn-Worker_idWorker_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE "Turn-Worker_idWorker_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Turn-Worker_idWorker_seq" OWNED BY "Turn-Worker"."idWorker";


--
-- TOC entry 237 (class 1259 OID 16813)
-- Name: TurnReport; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "TurnReport" (
    "idReport" integer NOT NULL,
    "brokenAmount" integer,
    "finishedAmount" integer,
    date date,
    start time(0) without time zone,
    "end" time(0) without time zone,
    product text,
    process text,
    "idWorker" integer NOT NULL
);



CREATE SEQUENCE "TurnReport_idReport_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;



ALTER SEQUENCE "TurnReport_idReport_seq" OWNED BY "TurnReport"."idReport";


--
-- TOC entry 254 (class 1259 OID 17028)
-- Name: TurnReport_idWorker_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE "TurnReport_idWorker_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "TurnReport_idWorker_seq" OWNED BY "TurnReport"."idWorker";


--
-- TOC entry 228 (class 1259 OID 16738)
-- Name: UnitOfMeasurement; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "UnitOfMeasurement" (
    id_unit integer NOT NULL,
    name text NOT NULL,
    abbreviature text NOT NULL,
    status text NOT NULL
);


CREATE SEQUENCE "UnitOfMeasurement_idUnit_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "UnitOfMeasurement_idUnit_seq" OWNED BY "UnitOfMeasurement".id_unit;


--
-- TOC entry 202 (class 1259 OID 16476)
-- Name: User; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "User" (
    id_user integer NOT NULL,
    description text,
    status integer,
    username text NOT NULL,
    password text,
    id_role integer,
    photo bytea,
    need_pass_reset boolean
);


CREATE SEQUENCE "User_idUser_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "User_idUser_seq" OWNED BY "User".id_user;


--
-- TOC entry 247 (class 1259 OID 16906)
-- Name: Warehouse; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Warehouse" (
    "idWarehouse" integer NOT NULL,
    name text NOT NULL,
    description text NOT NULL,
    address text NOT NULL,
    state text NOT NULL
);


CREATE TABLE "Warehouse_Product_Available" (
    id integer NOT NULL,
    id_warehouse integer,
    id_product integer,
    date date
);

CREATE SEQUENCE "Warehouse_Product_Available_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Warehouse_Product_Available_id_seq" OWNED BY "Warehouse_Product_Available".id;


--
-- TOC entry 246 (class 1259 OID 16904)
-- Name: Warehouse_idWarehouse_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE "Warehouse_idWarehouse_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Warehouse_idWarehouse_seq" OWNED BY "Warehouse"."idWarehouse";


--
-- TOC entry 243 (class 1259 OID 16848)
-- Name: Workstation; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "Workstation" (
    "idWorkstation" integer NOT NULL,
    "idWorker" integer,
    description text,
    state integer
);


CREATE SEQUENCE "Workstation_idWorkstation_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "Workstation_idWorkstation_seq" OWNED BY "Workstation"."idWorkstation";


--
-- TOC entry 215 (class 1259 OID 16606)
-- Name: cliente_idcliente_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE cliente_idcliente_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 2147483647
    CACHE 1;


CREATE SEQUENCE devolucion_iddevolucion_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 2147483647
    CACHE 1;



CREATE SEQUENCE lineapedido_idlineapedido_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 2147483647
    CACHE 1;



CREATE SEQUENCE pedido_idpedido_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 2147483647
    CACHE 1;



CREATE SEQUENCE "receta_idReceta_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;



ALTER SEQUENCE "receta_idReceta_seq" OWNED BY "Recipe"."idRecipe";


--
-- TOC entry 199 (class 1259 OID 16461)
-- Name: table_idTurno_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE "table_idTurno_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "table_idTurno_seq" OWNED BY "Turn"."idTurn";


--
-- TOC entry 275 (class 1259 OID 17613)
-- Name: table_id_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE table_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE table_id_seq OWNED BY "StockDocument".id;


--
-- TOC entry 280 (class 1259 OID 17656)
-- Name: temporaryStock; Type: TABLE; Schema: inkaart; Owner: admin
--

CREATE TABLE "temporaryStock" (
    "idTemporaryStock" integer NOT NULL,
    "idDocument" integer,
    "idProduct" integer,
    stock integer,
    "documentType" text
);

CREATE SEQUENCE "temporaryStock_idTemporaryStock_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE "temporaryStock_idTemporaryStock_seq" OWNED BY "temporaryStock"."idTemporaryStock";


--
-- TOC entry 219 (class 1259 OID 16626)
-- Name: tipodocumento_idtipodocumento_seq; Type: SEQUENCE; Schema: inkaart; Owner: admin
--

CREATE SEQUENCE tipodocumento_idtipodocumento_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 2147483647
    CACHE 1;


CREATE SEQUENCE workerindex_idproduct_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 2147483647
    CACHE 1;


CREATE SEQUENCE workerindex_idworker_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 2147483647
    CACHE 1;


ALTER TABLE ONLY "Assignment" ALTER COLUMN id_assignment SET DEFAULT nextval('"Assignment_id_assignment_seq1"'::regclass);


--
-- TOC entry 2391 (class 2604 OID 17703)
-- Name: AssignmentLine id_assignment_line; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "AssignmentLine" ALTER COLUMN id_assignment_line SET DEFAULT nextval('"Assignment_id_assignment_seq"'::regclass);


--
-- TOC entry 2378 (class 2604 OID 17524)
-- Name: Index id_index; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Index" ALTER COLUMN id_index SET DEFAULT nextval('"Index_idIndex_seq"'::regclass);


--
-- TOC entry 2393 (class 2604 OID 17793)
-- Name: Line-Document idLineDocument; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Line-Document" ALTER COLUMN "idLineDocument" SET DEFAULT nextval('"Line-Document_idLineDocument_seq"'::regclass);


--
-- TOC entry 2371 (class 2604 OID 17077)
-- Name: Movement idMovement; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Movement" ALTER COLUMN "idMovement" SET DEFAULT nextval('"Movement_idMovement_seq"'::regclass);


--
-- TOC entry 2356 (class 2604 OID 16786)
-- Name: MovementName idMovName; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "MovementName" ALTER COLUMN "idMovName" SET DEFAULT nextval('"MovementName_idMovName_seq"'::regclass);


--
-- TOC entry 2357 (class 2604 OID 16794)
-- Name: MovementType idMovementType; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "MovementType" ALTER COLUMN "idMovementType" SET DEFAULT nextval('"MovementType_idMovementType_seq"'::regclass);


--
-- TOC entry 2370 (class 2604 OID 17050)
-- Name: NoteDetail idNote; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "NoteDetail" ALTER COLUMN "idNote" SET DEFAULT nextval('"NoteDetail_idNote_seq"'::regclass);


--
-- TOC entry 2355 (class 2604 OID 16775)
-- Name: NoteType idNoteType; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "NoteType" ALTER COLUMN "idNoteType" SET DEFAULT nextval('"NoteType_idNoteType_seq"'::regclass);


--
-- TOC entry 2368 (class 2604 OID 16963)
-- Name: Order idOrder; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Order" ALTER COLUMN "idOrder" SET DEFAULT nextval('"Order_idOrder_seq"'::regclass);


--
-- TOC entry 2350 (class 2604 OID 16640)
-- Name: Process id_process; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Process" ALTER COLUMN id_process SET DEFAULT nextval('"Process_idProcess_seq"'::regclass);


--
-- TOC entry 2354 (class 2604 OID 17150)
-- Name: Process-Product idJob; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Process-Product" ALTER COLUMN "idJob" SET DEFAULT nextval('"Process-Product_idJob_seq"'::regclass);


--
-- TOC entry 2352 (class 2604 OID 16674)
-- Name: Product idProduct; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Product" ALTER COLUMN "idProduct" SET DEFAULT nextval('"Product_idProduct_seq"'::regclass);


--
-- TOC entry 2367 (class 2604 OID 17425)
-- Name: Product-Warehouse idProductWarehouse; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Product-Warehouse" ALTER COLUMN "idProductWarehouse" SET DEFAULT nextval('"Product-Warehouse_idProductWarehouse_seq"'::regclass);


--
-- TOC entry 2351 (class 2604 OID 16652)
-- Name: ProductType idProductType; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "ProductType" ALTER COLUMN "idProductType" SET DEFAULT nextval('"ProductType_idProductType_seq"'::regclass);


--
-- TOC entry 2345 (class 2604 OID 16550)
-- Name: PurcharseOrder id_order; Type: DEFAULT; Schema: inkaart; Owner: postgres
--

ALTER TABLE ONLY "PurcharseOrder" ALTER COLUMN id_order SET DEFAULT nextval('"OrdenCompra_idOrden_seq"'::regclass);


--
-- TOC entry 2394 (class 2604 OID 17824)
-- Name: PurchaseDocument id_purchase_document; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "PurchaseDocument" ALTER COLUMN id_purchase_document SET DEFAULT nextval('"PurchaseDocument_id_purchase_document_seq"'::regclass);


--
-- TOC entry 2395 (class 2604 OID 17834)
-- Name: PurchaseDocumentLine id_purchase_document; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "PurchaseDocumentLine" ALTER COLUMN id_purchase_document SET DEFAULT nextval('"PurchaseDocument_id_purchase_document_seq"'::regclass);


--
-- TOC entry 2396 (class 2604 OID 17835)
-- Name: PurchaseDocumentLine id_line_purchase_doc; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "PurchaseDocumentLine" ALTER COLUMN id_line_purchase_doc SET DEFAULT nextval('"PurchaseDocumentLine_id_line_purchase_doc_seq"'::regclass);


--
-- TOC entry 2375 (class 2604 OID 17410)
-- Name: PurchaseOrderDetail id_detail; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "PurchaseOrderDetail" ALTER COLUMN id_detail SET DEFAULT nextval('"PurchaseOrderDetail_id_detail_seq"'::regclass);


--
-- TOC entry 2376 (class 2604 OID 17516)
-- Name: Ratio id_ratio; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Ratio" ALTER COLUMN id_ratio SET DEFAULT nextval('"Ratio_idRatio_seq"'::regclass);


--
-- TOC entry 2380 (class 2604 OID 17566)
-- Name: RatioPerDay id_ratioperday; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "RatioPerDay" ALTER COLUMN id_ratioperday SET DEFAULT nextval('"RatioPerDay_id_seq"'::regclass);


--
-- TOC entry 2343 (class 2604 OID 16509)
-- Name: RawMaterial id_raw_material; Type: DEFAULT; Schema: inkaart; Owner: postgres
--

ALTER TABLE ONLY "RawMaterial" ALTER COLUMN id_raw_material SET DEFAULT nextval('"MateriaPrima_idMateria_seq"'::regclass);


--
-- TOC entry 2374 (class 2604 OID 17603)
-- Name: RawMaterial-Supplier id_rawmaterial_supplier; Type: DEFAULT; Schema: inkaart; Owner: postgres
--

ALTER TABLE ONLY "RawMaterial-Supplier" ALTER COLUMN id_rawmaterial_supplier SET DEFAULT nextval('"RawMaterial-Supplier_id_rawmaterial_supplier_seq"'::regclass);


--
-- TOC entry 2366 (class 2604 OID 17438)
-- Name: RawMaterial-Warehouse idRawMaterialWarehouse; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "RawMaterial-Warehouse" ALTER COLUMN "idRawMaterialWarehouse" SET DEFAULT nextval('"RawMaterial-Warehouse_idRawMaterialWarehouse_seq"'::regclass);


--
-- TOC entry 2342 (class 2604 OID 16498)
-- Name: Recipe idRecipe; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Recipe" ALTER COLUMN "idRecipe" SET DEFAULT nextval('"receta_idReceta_seq"'::regclass);


--
-- TOC entry 2369 (class 2604 OID 17009)
-- Name: Role id_role; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Role" ALTER COLUMN id_role SET DEFAULT nextval('"Role_idRole_seq"'::regclass);


--
-- TOC entry 2364 (class 2604 OID 16867)
-- Name: SalesDocument idSalesDocument; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "SalesDocument" ALTER COLUMN "idSalesDocument" SET DEFAULT nextval('"SalesDocument_idSalesDocument_seq"'::regclass);


--
-- TOC entry 2385 (class 2604 OID 17684)
-- Name: Simulation id_simulation; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Simulation" ALTER COLUMN id_simulation SET DEFAULT nextval('"Simulation_id_simulation_seq"'::regclass);


--
-- TOC entry 2398 (class 2604 OID 17900)
-- Name: Simulation-Order id_simulation_order; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Simulation-Order" ALTER COLUMN id_simulation_order SET DEFAULT nextval('"Simulation-Order_id_simulation_order_seq"'::regclass);


--
-- TOC entry 2397 (class 2604 OID 17877)
-- Name: Simulation-Worker id_simulation_worker; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Simulation-Worker" ALTER COLUMN id_simulation_worker SET DEFAULT nextval('"Simulation-Worker_id_simulation_worker_seq"'::regclass);


--
-- TOC entry 2381 (class 2604 OID 17618)
-- Name: StockDocument id; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "StockDocument" ALTER COLUMN id SET DEFAULT nextval('table_id_seq'::regclass);


--
-- TOC entry 2344 (class 2604 OID 16520)
-- Name: Supplier id_supplier; Type: DEFAULT; Schema: inkaart; Owner: postgres
--

ALTER TABLE ONLY "Supplier" ALTER COLUMN id_supplier SET DEFAULT nextval('"Proveedor_idProveedor_seq"'::regclass);


--
-- TOC entry 2340 (class 2604 OID 16466)
-- Name: Turn idTurn; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Turn" ALTER COLUMN "idTurn" SET DEFAULT nextval('"table_idTurno_seq"'::regclass);


--
-- TOC entry 2360 (class 2604 OID 16828)
-- Name: Turn-Worker idTurn; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Turn-Worker" ALTER COLUMN "idTurn" SET DEFAULT nextval('"Turn-Worker_idTurn_seq"'::regclass);


--
-- TOC entry 2361 (class 2604 OID 16829)
-- Name: Turn-Worker idReport; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Turn-Worker" ALTER COLUMN "idReport" SET DEFAULT nextval('"Turn-Worker_idReport_seq"'::regclass);


--
-- TOC entry 2362 (class 2604 OID 16830)
-- Name: Turn-Worker idWorker; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Turn-Worker" ALTER COLUMN "idWorker" SET DEFAULT nextval('"Turn-Worker_idWorker_seq"'::regclass);


--
-- TOC entry 2358 (class 2604 OID 16816)
-- Name: TurnReport idReport; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "TurnReport" ALTER COLUMN "idReport" SET DEFAULT nextval('"TurnReport_idReport_seq"'::regclass);


--
-- TOC entry 2359 (class 2604 OID 17030)
-- Name: TurnReport idWorker; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "TurnReport" ALTER COLUMN "idWorker" SET DEFAULT nextval('"TurnReport_idWorker_seq"'::regclass);


--
-- TOC entry 2353 (class 2604 OID 16741)
-- Name: UnitOfMeasurement id_unit; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "UnitOfMeasurement" ALTER COLUMN id_unit SET DEFAULT nextval('"UnitOfMeasurement_idUnit_seq"'::regclass);


--
-- TOC entry 2341 (class 2604 OID 16479)
-- Name: User id_user; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "User" ALTER COLUMN id_user SET DEFAULT nextval('"User_idUser_seq"'::regclass);


--
-- TOC entry 2365 (class 2604 OID 16909)
-- Name: Warehouse idWarehouse; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Warehouse" ALTER COLUMN "idWarehouse" SET DEFAULT nextval('"Warehouse_idWarehouse_seq"'::regclass);


--
-- TOC entry 2383 (class 2604 OID 17645)
-- Name: Warehouse_Product_Available id; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Warehouse_Product_Available" ALTER COLUMN id SET DEFAULT nextval('"Warehouse_Product_Available_id_seq"'::regclass);


--
-- TOC entry 2339 (class 2604 OID 16453)
-- Name: Worker id_worker; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Worker" ALTER COLUMN id_worker SET DEFAULT nextval('"Person_id_seq"'::regclass);


--
-- TOC entry 2363 (class 2604 OID 16851)
-- Name: Workstation idWorkstation; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Workstation" ALTER COLUMN "idWorkstation" SET DEFAULT nextval('"Workstation_idWorkstation_seq"'::regclass);


--
-- TOC entry 2384 (class 2604 OID 17659)
-- Name: temporaryStock idTemporaryStock; Type: DEFAULT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "temporaryStock" ALTER COLUMN "idTemporaryStock" SET DEFAULT nextval('"temporaryStock_idTemporaryStock_seq"'::regclass);


--
-- TOC entry 2480 (class 2606 OID 17742)
-- Name: Assignment AssignmentPerDay_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Assignment"
    ADD CONSTRAINT "AssignmentPerDay_pkey" PRIMARY KEY (id_assignment);


--
-- TOC entry 2478 (class 2606 OID 17705)
-- Name: AssignmentLine Assignment_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "AssignmentLine"
    ADD CONSTRAINT "Assignment_pkey" PRIMARY KEY (id_assignment_line);


--
-- TOC entry 2468 (class 2606 OID 17526)
-- Name: Index Index_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Index"
    ADD CONSTRAINT "Index_pkey" PRIMARY KEY (id_index);


--
-- TOC entry 2482 (class 2606 OID 17795)
-- Name: Line-Document Line-Document_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Line-Document"
    ADD CONSTRAINT "Line-Document_pkey" PRIMARY KEY ("idLineDocument");


--
-- TOC entry 2410 (class 2606 OID 16514)
-- Name: RawMaterial MateriaPrima_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: postgres
--

ALTER TABLE ONLY "RawMaterial"
    ADD CONSTRAINT "MateriaPrima_pkey" PRIMARY KEY (id_raw_material);


--
-- TOC entry 2438 (class 2606 OID 16788)
-- Name: MovementName MovementName_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "MovementName"
    ADD CONSTRAINT "MovementName_pkey" PRIMARY KEY ("idMovName");


--
-- TOC entry 2440 (class 2606 OID 16799)
-- Name: MovementType MovementType_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "MovementType"
    ADD CONSTRAINT "MovementType_pkey" PRIMARY KEY ("idMovementType");


--
-- TOC entry 2458 (class 2606 OID 17055)
-- Name: NoteDetail NoteDetail_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "NoteDetail"
    ADD CONSTRAINT "NoteDetail_pkey" PRIMARY KEY ("idNote");


--
-- TOC entry 2436 (class 2606 OID 16780)
-- Name: NoteType NoteType_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "NoteType"
    ADD CONSTRAINT "NoteType_pkey" PRIMARY KEY ("idNoteType");


--
-- TOC entry 2416 (class 2606 OID 16555)
-- Name: PurcharseOrder OrdenCompra_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: postgres
--

ALTER TABLE ONLY "PurcharseOrder"
    ADD CONSTRAINT "OrdenCompra_pkey" PRIMARY KEY (id_order);


--
-- TOC entry 2454 (class 2606 OID 16968)
-- Name: Order Order_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Order"
    ADD CONSTRAINT "Order_pkey" PRIMARY KEY ("idOrder");


--
-- TOC entry 2400 (class 2606 OID 16458)
-- Name: Worker Person_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Worker"
    ADD CONSTRAINT "Person_pkey" PRIMARY KEY (id_worker);


--
-- TOC entry 2434 (class 2606 OID 17152)
-- Name: Process-Product Process-Product_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Process-Product"
    ADD CONSTRAINT "Process-Product_pkey" PRIMARY KEY ("idJob");


--
-- TOC entry 2426 (class 2606 OID 16645)
-- Name: Process Process_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Process"
    ADD CONSTRAINT "Process_pkey" PRIMARY KEY (id_process);


--
-- TOC entry 2452 (class 2606 OID 17427)
-- Name: Product-Warehouse Product-Warehouse_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Product-Warehouse"
    ADD CONSTRAINT "Product-Warehouse_pkey" PRIMARY KEY ("idProductWarehouse");


--
-- TOC entry 2428 (class 2606 OID 16657)
-- Name: ProductType ProductType_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "ProductType"
    ADD CONSTRAINT "ProductType_pkey" PRIMARY KEY ("idProductType");


--
-- TOC entry 2430 (class 2606 OID 16679)
-- Name: Product Product_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Product"
    ADD CONSTRAINT "Product_pkey" PRIMARY KEY ("idProduct");


--
-- TOC entry 2412 (class 2606 OID 16525)
-- Name: Supplier Proveedor_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: postgres
--

ALTER TABLE ONLY "Supplier"
    ADD CONSTRAINT "Proveedor_pkey" PRIMARY KEY (id_supplier);


--
-- TOC entry 2486 (class 2606 OID 17837)
-- Name: PurchaseDocumentLine PurchaseDocumentLine_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "PurchaseDocumentLine"
    ADD CONSTRAINT "PurchaseDocumentLine_pkey" PRIMARY KEY (id_purchase_document);


--
-- TOC entry 2484 (class 2606 OID 17826)
-- Name: PurchaseDocument PurchaseDocument_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "PurchaseDocument"
    ADD CONSTRAINT "PurchaseDocument_pkey" PRIMARY KEY (id_purchase_document);


--
-- TOC entry 2464 (class 2606 OID 17412)
-- Name: PurchaseOrderDetail PurchaseOrderDetail_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "PurchaseOrderDetail"
    ADD CONSTRAINT "PurchaseOrderDetail_pkey" PRIMARY KEY (id_detail);


--
-- TOC entry 2470 (class 2606 OID 17574)
-- Name: RatioPerDay RatioPerDay_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "RatioPerDay"
    ADD CONSTRAINT "RatioPerDay_pkey" PRIMARY KEY (id_ratioperday);


--
-- TOC entry 2466 (class 2606 OID 17518)
-- Name: Ratio Ratio_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Ratio"
    ADD CONSTRAINT "Ratio_pkey" PRIMARY KEY (id_ratio);


--
-- TOC entry 2462 (class 2606 OID 17605)
-- Name: RawMaterial-Supplier RawMaterial-Supplier_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: postgres
--

ALTER TABLE ONLY "RawMaterial-Supplier"
    ADD CONSTRAINT "RawMaterial-Supplier_pkey" PRIMARY KEY (id_rawmaterial_supplier);


--
-- TOC entry 2450 (class 2606 OID 17440)
-- Name: RawMaterial-Warehouse RawMaterial-Warehouse_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "RawMaterial-Warehouse"
    ADD CONSTRAINT "RawMaterial-Warehouse_pkey" PRIMARY KEY ("idRawMaterialWarehouse");


--
-- TOC entry 2456 (class 2606 OID 17014)
-- Name: Role Role_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Role"
    ADD CONSTRAINT "Role_pkey" PRIMARY KEY (id_role);


--
-- TOC entry 2446 (class 2606 OID 16869)
-- Name: SalesDocument SalesDocument_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "SalesDocument"
    ADD CONSTRAINT "SalesDocument_pkey" PRIMARY KEY ("idSalesDocument");


--
-- TOC entry 2490 (class 2606 OID 17902)
-- Name: Simulation-Order Simulation-Order_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Simulation-Order"
    ADD CONSTRAINT "Simulation-Order_pkey" PRIMARY KEY (id_simulation_order);


--
-- TOC entry 2488 (class 2606 OID 17879)
-- Name: Simulation-Worker Simulation-Worker_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Simulation-Worker"
    ADD CONSTRAINT "Simulation-Worker_pkey" PRIMARY KEY (id_simulation_worker);


--
-- TOC entry 2476 (class 2606 OID 17692)
-- Name: Simulation SimulationParameters_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Simulation"
    ADD CONSTRAINT "SimulationParameters_pkey" PRIMARY KEY (id_simulation);


--
-- TOC entry 2414 (class 2606 OID 17461)
-- Name: Supplier Supplier_ruc_key; Type: CONSTRAINT; Schema: inkaart; Owner: postgres
--

ALTER TABLE ONLY "Supplier"
    ADD CONSTRAINT "Supplier_ruc_key" UNIQUE (ruc);


--
-- TOC entry 2424 (class 2606 OID 16629)
-- Name: DocumentType TipoDocumento_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "DocumentType"
    ADD CONSTRAINT "TipoDocumento_pkey" PRIMARY KEY ("idTipoDocumento");


--
-- TOC entry 2442 (class 2606 OID 16818)
-- Name: TurnReport TurnReport_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "TurnReport"
    ADD CONSTRAINT "TurnReport_pkey" PRIMARY KEY ("idReport");


--
-- TOC entry 2432 (class 2606 OID 16746)
-- Name: UnitOfMeasurement UnitOfMeasurement_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "UnitOfMeasurement"
    ADD CONSTRAINT "UnitOfMeasurement_pkey" PRIMARY KEY (id_unit);


--
-- TOC entry 2404 (class 2606 OID 16484)
-- Name: User User_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY (id_user);


--
-- TOC entry 2406 (class 2606 OID 16632)
-- Name: User User_username_key; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "User"
    ADD CONSTRAINT "User_username_key" UNIQUE (username);


--
-- TOC entry 2448 (class 2606 OID 16914)
-- Name: Warehouse Warehouse_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Warehouse"
    ADD CONSTRAINT "Warehouse_pkey" PRIMARY KEY ("idWarehouse");


--
-- TOC entry 2444 (class 2606 OID 16856)
-- Name: Workstation Workstation_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Workstation"
    ADD CONSTRAINT "Workstation_pkey" PRIMARY KEY ("idWorkstation");


--
-- TOC entry 2422 (class 2606 OID 16609)
-- Name: Client cliente_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Client"
    ADD CONSTRAINT cliente_pkey PRIMARY KEY ("idClient");


--
-- TOC entry 2418 (class 2606 OID 16614)
-- Name: Return devolucion_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Return"
    ADD CONSTRAINT devolucion_pkey PRIMARY KEY ("idReturn");


--
-- TOC entry 2420 (class 2606 OID 16619)
-- Name: LineItem lineapedido_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "LineItem"
    ADD CONSTRAINT lineapedido_pkey PRIMARY KEY ("idLineItem");


--
-- TOC entry 2408 (class 2606 OID 16503)
-- Name: Recipe receta_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Recipe"
    ADD CONSTRAINT receta_pkey PRIMARY KEY ("idRecipe");


--
-- TOC entry 2402 (class 2606 OID 16468)
-- Name: Turn table_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Turn"
    ADD CONSTRAINT table_pkey PRIMARY KEY ("idTurn");


--
-- TOC entry 2460 (class 2606 OID 17079)
-- Name: Movement table_pkey1; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Movement"
    ADD CONSTRAINT table_pkey1 PRIMARY KEY ("idMovement");


--
-- TOC entry 2472 (class 2606 OID 17623)
-- Name: StockDocument table_pkey2; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "StockDocument"
    ADD CONSTRAINT table_pkey2 PRIMARY KEY (id);


--
-- TOC entry 2474 (class 2606 OID 17661)
-- Name: temporaryStock temporaryStock_pkey; Type: CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "temporaryStock"
    ADD CONSTRAINT "temporaryStock_pkey" PRIMARY KEY ("idTemporaryStock");


--
-- TOC entry 2528 (class 2620 OID 17649)
-- Name: RatioPerDay ratio_per_day_tr; Type: TRIGGER; Schema: inkaart; Owner: admin
--

CREATE TRIGGER ratio_per_day_tr AFTER INSERT ON "RatioPerDay" FOR EACH ROW EXECUTE PROCEDURE getidlote();


--
-- TOC entry 2520 (class 2606 OID 18031)
-- Name: AssignmentLine Assignment_fk; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "AssignmentLine"
    ADD CONSTRAINT "Assignment_fk" FOREIGN KEY (id_assignment) REFERENCES "Assignment"(id_assignment) ON DELETE CASCADE;


--
-- TOC entry 2517 (class 2606 OID 17706)
-- Name: AssignmentLine Assignment_id_process_product_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "AssignmentLine"
    ADD CONSTRAINT "Assignment_id_process_product_fkey" FOREIGN KEY (id_job) REFERENCES "Process-Product"("idJob");


--
-- TOC entry 2518 (class 2606 OID 17711)
-- Name: AssignmentLine Assignment_id_recipe_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "AssignmentLine"
    ADD CONSTRAINT "Assignment_id_recipe_fkey" FOREIGN KEY (id_recipe) REFERENCES "Recipe"("idRecipe");


--
-- TOC entry 2519 (class 2606 OID 17716)
-- Name: AssignmentLine Assignment_id_worker_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "AssignmentLine"
    ADD CONSTRAINT "Assignment_id_worker_fkey" FOREIGN KEY (id_worker) REFERENCES "Worker"(id_worker);


--
-- TOC entry 2522 (class 2606 OID 17781)
-- Name: Line-Document Line-Document_idLineItem_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Line-Document"
    ADD CONSTRAINT "Line-Document_idLineItem_fkey" FOREIGN KEY ("idLineItem") REFERENCES "LineItem"("idLineItem");


--
-- TOC entry 2523 (class 2606 OID 17786)
-- Name: Line-Document Line-Document_idSaleDocument_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Line-Document"
    ADD CONSTRAINT "Line-Document_idSaleDocument_fkey" FOREIGN KEY ("idSaleDocument") REFERENCES "SalesDocument"("idSalesDocument");


--
-- TOC entry 2497 (class 2606 OID 16709)
-- Name: LineItem LineItem_fk; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "LineItem"
    ADD CONSTRAINT "LineItem_fk" FOREIGN KEY ("idProduct") REFERENCES "Product"("idProduct");


--
-- TOC entry 2496 (class 2606 OID 16704)
-- Name: LineItem LineItem_fk1; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "LineItem"
    ADD CONSTRAINT "LineItem_fk1" FOREIGN KEY ("idRecipe") REFERENCES "Recipe"("idRecipe");


--
-- TOC entry 2498 (class 2606 OID 17020)
-- Name: LineItem LineItem_idOrder_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "LineItem"
    ADD CONSTRAINT "LineItem_idOrder_fkey" FOREIGN KEY ("idOrder") REFERENCES "Order"("idOrder");


--
-- TOC entry 2514 (class 2606 OID 17343)
-- Name: RawMaterial-Supplier MateriaXProveedor_fk; Type: FK CONSTRAINT; Schema: inkaart; Owner: postgres
--

ALTER TABLE ONLY "RawMaterial-Supplier"
    ADD CONSTRAINT "MateriaXProveedor_fk" FOREIGN KEY (id_supplier) REFERENCES "Supplier"(id_supplier);


--
-- TOC entry 2515 (class 2606 OID 17348)
-- Name: RawMaterial-Supplier MateriaXProveedor_fk1; Type: FK CONSTRAINT; Schema: inkaart; Owner: postgres
--

ALTER TABLE ONLY "RawMaterial-Supplier"
    ADD CONSTRAINT "MateriaXProveedor_fk1" FOREIGN KEY (id_raw_material) REFERENCES "RawMaterial"(id_raw_material);


--
-- TOC entry 2495 (class 2606 OID 16556)
-- Name: PurcharseOrder OrdenCompra_fk; Type: FK CONSTRAINT; Schema: inkaart; Owner: postgres
--

ALTER TABLE ONLY "PurcharseOrder"
    ADD CONSTRAINT "OrdenCompra_fk" FOREIGN KEY (id_supplier) REFERENCES "Supplier"(id_supplier);


--
-- TOC entry 2526 (class 2606 OID 17903)
-- Name: Simulation-Order Order_fk; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Simulation-Order"
    ADD CONSTRAINT "Order_fk" FOREIGN KEY (id_order) REFERENCES "Order"("idOrder");


--
-- TOC entry 2513 (class 2606 OID 16969)
-- Name: Order Order_idClient_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Order"
    ADD CONSTRAINT "Order_idClient_fkey" FOREIGN KEY ("idClient") REFERENCES "Client"("idClient");


--
-- TOC entry 2491 (class 2606 OID 16469)
-- Name: Worker Person_fk; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Worker"
    ADD CONSTRAINT "Person_fk" FOREIGN KEY (turn) REFERENCES "Turn"("idTurn");


--
-- TOC entry 2492 (class 2606 OID 16488)
-- Name: Worker Person_fk1; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Worker"
    ADD CONSTRAINT "Person_fk1" FOREIGN KEY (id_user) REFERENCES "User"(id_user);


--
-- TOC entry 2501 (class 2606 OID 16752)
-- Name: Process-Product Process-Product_fk; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Process-Product"
    ADD CONSTRAINT "Process-Product_fk" FOREIGN KEY ("idProduct") REFERENCES "Product"("idProduct");


--
-- TOC entry 2502 (class 2606 OID 16757)
-- Name: Process-Product Process-Product_fk1; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Process-Product"
    ADD CONSTRAINT "Process-Product_fk1" FOREIGN KEY ("idProcess") REFERENCES "Process"(id_process);


--
-- TOC entry 2511 (class 2606 OID 16937)
-- Name: Product-Warehouse Product-Warehouse_idProduct_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Product-Warehouse"
    ADD CONSTRAINT "Product-Warehouse_idProduct_fkey" FOREIGN KEY ("idProduct") REFERENCES "Product"("idProduct");


--
-- TOC entry 2512 (class 2606 OID 16942)
-- Name: Product-Warehouse Product-Warehouse_idWarehouse_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Product-Warehouse"
    ADD CONSTRAINT "Product-Warehouse_idWarehouse_fkey" FOREIGN KEY ("idWarehouse") REFERENCES "Warehouse"("idWarehouse");


--
-- TOC entry 2516 (class 2606 OID 17403)
-- Name: PurchaseOrderDetail PurchaseOrderDetail_fk; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "PurchaseOrderDetail"
    ADD CONSTRAINT "PurchaseOrderDetail_fk" FOREIGN KEY (id_order) REFERENCES "PurcharseOrder"(id_order);


--
-- TOC entry 2510 (class 2606 OID 16926)
-- Name: RawMaterial-Warehouse RawMaterial-Warehouse_idRawMaterial_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "RawMaterial-Warehouse"
    ADD CONSTRAINT "RawMaterial-Warehouse_idRawMaterial_fkey" FOREIGN KEY ("idRawMaterial") REFERENCES "RawMaterial"(id_raw_material);


--
-- TOC entry 2509 (class 2606 OID 16921)
-- Name: RawMaterial-Warehouse RawMaterial-Warehouse_idWarehouse_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "RawMaterial-Warehouse"
    ADD CONSTRAINT "RawMaterial-Warehouse_idWarehouse_fkey" FOREIGN KEY ("idWarehouse") REFERENCES "Warehouse"("idWarehouse");


--
-- TOC entry 2499 (class 2606 OID 16683)
-- Name: Recipe-RawMaterial Recipe-RawMaterial_fk; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Recipe-RawMaterial"
    ADD CONSTRAINT "Recipe-RawMaterial_fk" FOREIGN KEY ("idRecipe") REFERENCES "Recipe"("idRecipe");


--
-- TOC entry 2500 (class 2606 OID 16688)
-- Name: Recipe-RawMaterial Recipe-RawMaterial_fk1; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Recipe-RawMaterial"
    ADD CONSTRAINT "Recipe-RawMaterial_fk1" FOREIGN KEY ("idRawMaterial") REFERENCES "RawMaterial"(id_raw_material);


--
-- TOC entry 2494 (class 2606 OID 16875)
-- Name: Recipe Recipe_idProduct_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Recipe"
    ADD CONSTRAINT "Recipe_idProduct_fkey" FOREIGN KEY ("idProduct") REFERENCES "Product"("idProduct");


--
-- TOC entry 2507 (class 2606 OID 16870)
-- Name: SalesDocument SalesDocument_idDocumentType_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "SalesDocument"
    ADD CONSTRAINT "SalesDocument_idDocumentType_fkey" FOREIGN KEY ("idDocumentType") REFERENCES "DocumentType"("idTipoDocumento");


--
-- TOC entry 2508 (class 2606 OID 17448)
-- Name: SalesDocument SalesDocument_idOrder_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "SalesDocument"
    ADD CONSTRAINT "SalesDocument_idOrder_fkey" FOREIGN KEY ("idOrder") REFERENCES "Order"("idOrder");


--
-- TOC entry 2524 (class 2606 OID 17885)
-- Name: Simulation-Worker Simulation_fk; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Simulation-Worker"
    ADD CONSTRAINT "Simulation_fk" FOREIGN KEY (id_simulation) REFERENCES "Simulation"(id_simulation);


--
-- TOC entry 2527 (class 2606 OID 17908)
-- Name: Simulation-Order Simulation_fk; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Simulation-Order"
    ADD CONSTRAINT "Simulation_fk" FOREIGN KEY (id_simulation) REFERENCES "Simulation"(id_simulation);


--
-- TOC entry 2521 (class 2606 OID 18026)
-- Name: Assignment Simulation_fk; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Assignment"
    ADD CONSTRAINT "Simulation_fk" FOREIGN KEY (id_simulation) REFERENCES "Simulation"(id_simulation) ON DELETE CASCADE;


--
-- TOC entry 2504 (class 2606 OID 16836)
-- Name: Turn-Worker Turn-Worker_idReport_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Turn-Worker"
    ADD CONSTRAINT "Turn-Worker_idReport_fkey" FOREIGN KEY ("idReport") REFERENCES "TurnReport"("idReport");


--
-- TOC entry 2503 (class 2606 OID 16831)
-- Name: Turn-Worker Turn-Worker_idTurn_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Turn-Worker"
    ADD CONSTRAINT "Turn-Worker_idTurn_fkey" FOREIGN KEY ("idTurn") REFERENCES "Turn"("idTurn");


--
-- TOC entry 2505 (class 2606 OID 16841)
-- Name: Turn-Worker Turn-Worker_idWorker_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Turn-Worker"
    ADD CONSTRAINT "Turn-Worker_idWorker_fkey" FOREIGN KEY ("idWorker") REFERENCES "Worker"(id_worker);


--
-- TOC entry 2493 (class 2606 OID 17015)
-- Name: User User_fk; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "User"
    ADD CONSTRAINT "User_fk" FOREIGN KEY (id_role) REFERENCES "Role"(id_role);


--
-- TOC entry 2525 (class 2606 OID 17890)
-- Name: Simulation-Worker Worker_fk; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Simulation-Worker"
    ADD CONSTRAINT "Worker_fk" FOREIGN KEY (id_worker) REFERENCES "Worker"(id_worker);


--
-- TOC entry 2506 (class 2606 OID 16857)
-- Name: Workstation Workstation_idWorker_fkey; Type: FK CONSTRAINT; Schema: inkaart; Owner: admin
--

ALTER TABLE ONLY "Workstation"
    ADD CONSTRAINT "Workstation_idWorker_fkey" FOREIGN KEY ("idWorker") REFERENCES "Worker"(id_worker);


--
-- TOC entry 2651 (class 0 OID 0)
-- Dependencies: 14
-- Name: inkaart; Type: ACL; Schema: -; Owner: postgres
--

--GRANT ALL ON SCHEMA inkaart TO admin;
--GRANT USAGE ON SCHEMA inkaart TO dpuser;


-- Completed on 2017-07-01 13:14:28

--
-- PostgreSQL database dump complete
--

INSERT INTO "Turn" ("idTurn", start, "end", description) VALUES (1, '08:00:00', '10:00:00', '8:00 - 10:00');

INSERT INTO inkaart."MovementName" ("idMovName", description) VALUES (1, 'Compra');
INSERT INTO inkaart."MovementName" ("idMovName", description) VALUES (2, 'Venta');
INSERT INTO inkaart."MovementName" ("idMovName", description) VALUES (3, 'Produccion');
INSERT INTO inkaart."MovementName" ("idMovName", description) VALUES (4, 'Rotura');
INSERT INTO inkaart."MovementName" ("idMovName", description) VALUES (5, 'Traslado');
INSERT INTO inkaart."MovementName" ("idMovName", description) VALUES (7, 'Hallazgo');
INSERT INTO inkaart."MovementName" ("idMovName", description) VALUES (8, 'Devolución');
INSERT INTO inkaart."MovementName" ("idMovName", description) VALUES (9, 'Diferencia de stock');
INSERT INTO inkaart."MovementName" ("idMovName", description) VALUES (10, 'Facturación');

INSERT INTO inkaart."MovementType" ("idMovementType", description) VALUES (1, 'Entrada/Salida');
INSERT INTO inkaart."MovementType" ("idMovementType", description) VALUES (2, 'Entrada');
INSERT INTO inkaart."MovementType" ("idMovementType", description) VALUES (13, 'Salida');

CREATE OR REPLACE FUNCTION inkaart.GetIDLote() RETURNS TRIGGER AS $get_id_lote$
DECLARE
  max_id_lote integer;
BEGIN
  -- Buscar si ya existe el valor de id_lote
  SELECT MAX(id_lote) INTO max_id_lote FROM inkaart."RatioPerDay" WHERE date = NEW.date;
  -- Si es nulo, se generará uno nuevo
  IF (max_id_lote IS NULL) THEN
    SELECT MAX(id_lote) INTO max_id_lote FROM inkaart."RatioPerDay";
    IF (max_id_lote IS NULL) THEN
      max_id_lote = 1;
    ELSE
      max_id_lote = max_id_lote + 1;
    END IF;
  END IF;
  -- Actualizar la fila para colocar el id_lote
  UPDATE inkaart."RatioPerDay" SET id_lote = max_id_lote WHERE id_ratioperday = NEW.id_ratioperday;
  -- Devolver el trigger
  RETURN NEW;
END;    
$get_id_lote$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS ratio_per_day_tr ON inkaart."RatioPerDay";
CREATE TRIGGER ratio_per_day_tr AFTER INSERT ON inkaart."RatioPerDay"
FOR EACH ROW EXECUTE PROCEDURE inkaart.GetIDLote();