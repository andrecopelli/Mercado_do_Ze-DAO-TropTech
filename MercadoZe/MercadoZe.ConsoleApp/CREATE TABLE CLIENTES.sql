CREATE TABLE CLIENTES(
    CPF VARCHAR(11) NOT NULL,
    NOME VARCHAR(200) NOT NULL,
    DATA_NASCIMENTO DATETIME NOT NULL,
    PONTOS_FIDELIDADE INT,
    RUA VARCHAR(250) NOT NULL,
    NUMERO INT,
    BAIRRO VARCHAR(100),
    CEP VARCHAR(9) NOT NULL,
    COMPLEMENTO VARCHAR(250),
    CONSTRAINT PK_CLIENTE PRIMARY KEY (CPF)
);