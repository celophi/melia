ALTER TABLE `characters` DROP COLUMN `barrackIndex`;

ALTER TABLE `accounts` ADD `Medal` INT NOT NULL DEFAULT 0;
ALTER TABLE `accounts` ADD `GiftMedal` INT NOT NULL DEFAULT 0;
ALTER TABLE `accounts` ADD `PremiumMedal` INT NOT NULL DEFAULT 0;
