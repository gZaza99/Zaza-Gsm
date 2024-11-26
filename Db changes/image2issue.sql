ALTER TABLE `zaza-gsm`.`image_tbl` 
DROP FOREIGN KEY `image_tbl_ibfk_1`;
ALTER TABLE `zaza-gsm`.`image_tbl` 
CHANGE COLUMN `DeviceId_col` `IssueId_col` INT NOT NULL ,
ADD INDEX `image_tbl_ibfk_1_idx` (`IssueId_col` ASC) VISIBLE,
DROP INDEX `DeviceId_col` ;
;
ALTER TABLE `zaza-gsm`.`image_tbl` 
ADD CONSTRAINT `image_tbl_ibfk_1`
  FOREIGN KEY (`IssueId_col`)
  REFERENCES `zaza-gsm`.`issue_tbl` (`Id_col`);
