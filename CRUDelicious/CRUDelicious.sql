-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema dishes_db
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `dishes_db` ;

-- -----------------------------------------------------
-- Schema dishes_db
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `dishes_db` DEFAULT CHARACTER SET utf8 ;
USE `dishes_db` ;

-- -----------------------------------------------------
-- Table `dishes_db`.`Dishes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dishes_db`.`Dishes` (
  `DishId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL,
  `Chef` VARCHAR(45) NULL,
  `Tastiness` INT NULL,
  `Calories` INT NULL,
  `Description` TEXT NULL,
  `created_at` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` DATETIME NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`DishId`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
