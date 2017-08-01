CREATE TABLE IF NOT EXISTS `MapVisibility` (
    `id` bigint(20) NOT NULL AUTO_INCREMENT,
    `accountId` bigint(20) NOT NULL,
    `map` int(11) NOT NULL,
    `explored` varbinary(128) NOT NULL,
    PRIMARY KEY (`id`),
    CONSTRAINT `FK_MapVisibility_accountId` FOREIGN KEY (`accountId`) REFERENCES `accounts` (`accountId`) ON DELETE CASCADE,
    CONSTRAINT `UQ_MapVisibility_map` UNIQUE (`accountId`, `map`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1;
