---------------------------------------------------------------------------------------------
-- Este trigger NO se esta usando, favor de no agregarlo a structure.sql
---------------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION inkaart.SoftDeleteAssignments() RETURNS TRIGGER AS $soft_delete_assignments$
DECLARE
  assignment RECORD;
  assignment_cursor CURSOR FOR SELECT * FROM inkaart."Assignment" WHERE id_simulation = OLD.id_simulation;
BEGIN
  IF (OLD.status = TRUE AND NEW.status = FALSE) THEN
    -- Realizar soft deletion a las asignaciones cuyo id de simulacion sea el de la fila cambiada
    OPEN assignment_cursor;
    LOOP
      FETCH assignment_cursor INTO assignment;
      EXIT WHEN NOT FOUND;
      -- Cambiar el estado de la asignacion
      UPDATE inkaart."Assignment" SET status = FALSE WHERE CURRENT OF assignment;
      -- Realizar soft deletion a las lineas de asignacion cuyo id de asignacion sea el de la fila leida
      UPDATE inkaart."AssignmentLine" SET status = FALSE WHERE id_assignment_line = assignment.id_assignment;
	END LOOP;
    CLOSE assignment_cursor;
  END IF;
  RETURN NEW;
END;
$soft_delete_assignments$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS simulation_tr ON inkaart."Simulation";
CREATE TRIGGER simulation_tr AFTER UPDATE ON inkaart."Simulation"
FOR EACH ROW EXECUTE PROCEDURE inkaart.SoftDeleteAssignments();
