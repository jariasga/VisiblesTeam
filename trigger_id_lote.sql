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