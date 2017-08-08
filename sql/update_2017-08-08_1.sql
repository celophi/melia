CREATE TABLE IF NOT EXISTS `LoginHistory` (
    `id` bigint(20) NOT NULL AUTO_INCREMENT,
    `accountId` bigint(20) NOT NULL,
    `ipaddress` varchar(64) NOT NULL,
    `physicalAddress` varchar(64) NOT NULL,
    `loginTime` DATETIME NOT NULL,
    `logoutTime` DATETIME NULL DEFAULT NULL,
    PRIMARY KEY (`id`),
    CONSTRAINT `FK_LoginHistory_accountId` FOREIGN KEY (`accountId`) REFERENCES `accounts` (`accountId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1;

CREATE EVENT IF NOT EXISTS `AutoPurgeLoginHistory`
ON SCHEDULE AT CURRENT_TIMESTAMP + INTERVAL 1 DAY
ON COMPLETION PRESERVE
DO
DELETE LOW_PRIORITY FROM `melia`.`LoginHistory` WHERE `logoutTime` < DATE_SUB(NOW(), INTERVAL 30 DAY)
