-- Таблица ролей пользователей. Роли используются для разграничения доступа.
CREATE TABLE Roles (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Уникальный идентификатор роли
    Name NVARCHAR(50) NOT NULL UNIQUE,  -- Название роли (например, Admin, User)
    Description NVARCHAR(255)  -- Описание роли на русском: например, "Администратор системы"
);

-- Таблица пользователей. Хранит информацию о пользователях системы.
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Уникальный идентификатор пользователя
    FullName NVARCHAR(255) NOT NULL,  -- Полное имя пользователя (ФИО)
    Email NVARCHAR(255) NOT NULL UNIQUE,  -- Электронная почта пользователя
    PasswordHash VARCHAR(128) NOT NULL,  -- Хэш пароля (SHA512, 128 символов в hex)
    RoleId INT NOT NULL,  -- Идентификатор роли пользователя (внешний ключ к Roles)
    FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);

-- Таблица типов контрагентов. Определяет тип контрагента (физическое или юридическое лицо).
CREATE TABLE CounterpartyTypes (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Уникальный идентификатор типа
    Name NVARCHAR(50) NOT NULL UNIQUE,  -- Название типа (например, Individual, Legal)
    Description NVARCHAR(255)  -- Описание типа на русском: например, "Физическое лицо" или "Юридическое лицо"
);

-- Таблица контрагентов. Хранит информацию о контрагентах (отправителях документов).
CREATE TABLE Counterparties (
    INN VARCHAR(12) PRIMARY KEY,  -- ИНН контрагента (первичный ключ, 12 символов для РФ)
    TypeId INT NOT NULL,  -- Идентификатор типа контрагента (внешний ключ к CounterpartyTypes)
    ShortDescription NVARCHAR(500),  -- Краткое описание контрагента
    FOREIGN KEY (TypeId) REFERENCES CounterpartyTypes(Id)
);

-- Таблица типов документов. Определяет категории документов.
CREATE TABLE DocumentTypes (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Уникальный идентификатор типа документа
    Name NVARCHAR(100) NOT NULL UNIQUE,  -- Название типа документа (например, Contract, Invoice)
    Description NVARCHAR(255)  -- Описание типа на русском: например, "Договор" или "Счет"
);

-- Таблица расширений файлов. Хранит возможные расширения документов.
CREATE TABLE Extensions (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Уникальный идентификатор расширения
    Extension NVARCHAR(10) NOT NULL UNIQUE,  -- Расширение файла (например, pdf, docx)
    Description NVARCHAR(255)  -- Описание расширения на русском: например, "PDF документ"
);

-- Таблица ключевых слов. Хранит уникальные ключевые слова для документов.
CREATE TABLE Keywords (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Уникальный идентификатор ключевого слова
    Keyword NVARCHAR(100) NOT NULL UNIQUE,  -- Само ключевое слово
    Description NVARCHAR(255)  -- Описание ключевого слова на русском (опционально)
);

-- Таблица документов. Хранит информацию о документах, включая файл.
CREATE TABLE Documents (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Уникальный идентификатор документа
    Title NVARCHAR(255) NOT NULL,  -- Название документа
    ShortDescription NVARCHAR(1000),  -- Краткое описание документа (максимум 1000 символов)
    DateAdded DATETIME2 NOT NULL DEFAULT GETDATE(),  -- Дата добавления документа
    FileData VARBINARY(MAX),  -- Данные файла (максимальный размер для хранения бинарных данных)
    SenderId VARCHAR(12) NOT NULL,  -- ИНН отправителя документа (внешний ключ к Counterparties)
    TypeId INT NOT NULL,  -- Идентификатор типа документа (внешний ключ к DocumentTypes)
    ExtensionId INT NOT NULL,  -- Идентификатор расширения файла (внешний ключ к Extensions)
    FOREIGN KEY (SenderId) REFERENCES Counterparties(INN),
    FOREIGN KEY (TypeId) REFERENCES DocumentTypes(Id),
    FOREIGN KEY (ExtensionId) REFERENCES Extensions(Id)
);

-- Таблица связи документов и ключевых слов (многие-ко-многим).
CREATE TABLE DocumentKeywords (
    DocumentId INT NOT NULL,  -- Идентификатор документа (внешний ключ к Documents)
    KeywordId INT NOT NULL,  -- Идентификатор ключевого слова (внешний ключ к Keywords)
    PRIMARY KEY (DocumentId, KeywordId),
    FOREIGN KEY (DocumentId) REFERENCES Documents(Id),
    FOREIGN KEY (KeywordId) REFERENCES Keywords(Id)
);

-- Примеры вставки данных для тестирования (опционально, можно удалить).
-- Вставка типов контрагентов
INSERT INTO CounterpartyTypes (Name, Description) VALUES ('Individual', 'Физическое лицо');
INSERT INTO CounterpartyTypes (Name, Description) VALUES ('Legal', 'Юридическое лицо');

-- Вставка ролей
INSERT INTO Roles (Name, Description) VALUES ('Admin', 'Администратор системы');
INSERT INTO Roles (Name, Description) VALUES ('User', 'Обычный пользователь');

-- Вставка типов документов
INSERT INTO DocumentTypes (Name, Description) VALUES ('Contract', 'Договор');
INSERT INTO DocumentTypes (Name, Description) VALUES ('Invoice', 'Счет');

-- Вставка расширений
INSERT INTO Extensions (Extension, Description) VALUES ('pdf', 'PDF документ');
INSERT INTO Extensions (Extension, Description) VALUES ('docx', 'Word документ');