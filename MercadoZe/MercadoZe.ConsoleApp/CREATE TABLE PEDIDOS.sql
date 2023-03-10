CREATE TABLE PEDIDOS(
    ID INT IDENTITY(1,1) NOT NULL,
    DATAHORA DATETIME NOT NULL,
    ID_PRODUTO INT NOT NULL,
    QTD_PRODUTO INT NOT NULL,
    VALOR_PEDIDO DECIMAL(10,2) NOT NULL,
    ID_CLIENTE VARCHAR(11) NULL,
    CONSTRAINT PK_PEDIDO PRIMARY KEY (ID),
    CONSTRAINT FK_CLIENTE_PEDIDO FOREIGN KEY (ID_CLIENTE) REFERENCES CLIENTES(CPF),
    CONSTRAINT FK_PRODUTO_PEDIDO FOREIGN KEY (ID_PRODUTO) REFERENCES PRODUTOS(ID)
);