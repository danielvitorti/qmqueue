/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES  */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

CREATE TABLE IF NOT EXISTS QMQ_OUT_BODY_H (
    SOURCE TEXT NOT NULL,
    MESSAGE_ID TEXT NOT NULL,
    FIELD_SEQ INTEGER NOT NULL,
    FEATURE CHAR(40),
    VALUE VARCHAR(1000),
    PRIMARY KEY (SOURCE, MESSAGE_ID, FIELD_SEQ),
    FOREIGN KEY (SOURCE, MESSAGE_ID) REFERENCES QMQ_OUT_HEADER (SOURCE, MESSAGE_ID)
);

DELETE FROM "QMQ_OUT_BODY_H";
/*!40000 ALTER TABLE "QMQ_OUT_BODY_H" DISABLE KEYS */;
/*!40000 ALTER TABLE "QMQ_OUT_BODY_H" ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
