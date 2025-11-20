-- Add Type column if it doesn't exist
SET @column_exists = (
  SELECT COUNT(*)
  FROM information_schema.COLUMNS
  WHERE TABLE_SCHEMA = 'dbp_messenger'
  AND TABLE_NAME = 'favorites'
  AND COLUMN_NAME = 'type'
);

SET @sql = IF(@column_exists = 0,
  'ALTER TABLE favorites ADD COLUMN type longtext CHARACTER SET utf8mb4 NOT NULL DEFAULT ''EMPLOYEE'';',
  'SELECT ''Column type already exists'' AS message;'
);

PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

-- Add DisplayOrder column if it doesn't exist
SET @column_exists = (
  SELECT COUNT(*)
  FROM information_schema.COLUMNS
  WHERE TABLE_SCHEMA = 'dbp_messenger'
  AND TABLE_NAME = 'favorites'
  AND COLUMN_NAME = 'display_order'
);

SET @sql = IF(@column_exists = 0,
  'ALTER TABLE favorites ADD COLUMN display_order int NOT NULL DEFAULT 0;',
  'SELECT ''Column display_order already exists'' AS message;'
);

PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
