DROP TABLE IF EXISTS Alerta;
DROP TABLE IF EXISTS Drone;
DROP TABLE IF EXISTS AreaRisco;
DROP TABLE IF EXISTS Usuario;

CREATE TABLE Usuario (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    senha_hash VARCHAR(255) NOT NULL,
    nivel_acesso VARCHAR(20),
    status VARCHAR(10),
    data_criacao DATETIME2 DEFAULT SYSDATETIME(),
    data_atualizacao DATETIME2
);

CREATE TABLE AreaRisco (
    id_area INT IDENTITY(1,1) PRIMARY KEY,
    nome_area VARCHAR(100) NOT NULL,
    descricao VARCHAR(255),
    latitude DECIMAL(10, 8) NOT NULL,
    longitude DECIMAL(11, 8) NOT NULL,
    status VARCHAR(20),
    raio_cobertura DECIMAL(5, 2),
    data_cadastro DATETIME2 DEFAULT SYSDATETIME()
);

CREATE TABLE Drone (
    id_drone INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    modelo VARCHAR(50) NOT NULL,
    status VARCHAR(20),
    latitude DECIMAL(10, 8),
    longitude DECIMAL(11, 8),
    bateria INT,
    capacidade_carga DECIMAL(5, 2),
    data_ultima_manutencao DATETIME2,
    horario_operacao VARCHAR(20),
    data_cadastro DATETIME2 DEFAULT SYSDATETIME()
);

CREATE TABLE Alerta (
    id_alerta INT IDENTITY(1,1) PRIMARY KEY,
    tipo_alerta VARCHAR(20),
    data_hora DATETIME2 DEFAULT SYSDATETIME(),
    status VARCHAR(20),
    id_area INT NOT NULL,
    id_drone INT,
    id_usuario INT,
    gravidade VARCHAR(10),
    descricao VARCHAR(100),
    CONSTRAINT fk_alerta_area FOREIGN KEY (id_area) REFERENCES AreaRisco(id_area),
    CONSTRAINT fk_alerta_drone FOREIGN KEY (id_drone) REFERENCES Drone(id_drone),
    CONSTRAINT fk_alerta_usuario FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);
