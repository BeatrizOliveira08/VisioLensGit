create database visioLens;
use visioLens;

create table cliente (
id_cli int primary key auto_increment,
nome_cli varchar(200),
cpf_cli varchar(20),
telefone_cli varchar(20),
endereco_cli varchar(100),
email_cli varchar(100)
);

create table colaborador (
id_colab int primary key auto_increment,
nome_colab varchar(200),
data_nascimento_colab date,
telefone_colab varchar(20),
email_colab varchar(100)
);


create table tipo_de_sessao (
id_tip_ses int primary key auto_increment,
duracao_tip_ses varchar(200),
preco_padrao_tip_ses varchar(200),
quantidade_fotos_tip_ses varchar(300),
entrega_tip_ses date,
observacoes_tip_ses varchar(200),
categoria_tip_ses varchar(100)
);


create table orcamento (
id_orc int primary key auto_increment,
cliente_orc varchar(300),
fotografo_orc varchar(300),
pacote_fotos_orc varchar(300),
valor_total_orc varchar(100),
status_orc varchar(200),
forma_pagamento_orc varchar(200),
tipo_sessao_orc varchar(200)
);

create table pacote (
id_pac int primary key auto_increment,
nome_pac varchar(100),
descricao_pac varchar(200),
valor_pac varchar(100),
destinatario_pac varchar(100),
dimensoes_pac varchar(200)
);

create table agendamento (
id_agen int primary key auto_increment,
cliente_agen varchar(300),
data_agen date,
tipo_sessao_agen varchar(300),
duracao_agen varchar(100),
fotografo_agen varchar(300),
observacao_agen varchar(200)
);

create table pagamento (
id_pag int primary key auto_increment,
cliente_pag varchar(300),
fotografo_pag varchar(300),
pacote_contratado_pag varchar(300),
valor_pago_pag decimal,
valor_total_pag decimal,
valor_restante_pag decimal,
forma_pag varchar(100),
status_pag varchar(100)
);


select * from cliente;
#Inserindo dados na tabela cliente
insert into cliente values (null, 'Beatriz de Oliveira', '709.458.698-32', '(69) 99698-4574', 'Rua Andorinha Nº3242 Bairro:JK', 'beatriz123@gmail.com');
insert into cliente values (null, 'Maria Aparecida Pereira', '542.968.458-15', '(69) 99874-6547', 'Rua Castelo Branco Nº4575 Bairro:Riachuelo', 'apaecida523@gmail.com');
insert into cliente values (null, 'Maria Eduarda Silva', '698.745.859-20', '(69) 99236-7852', 'Rua Seis de Maio Nº1230 Bairro:Centro', 'mariaeduarda24@gmail.com');

select * from colaborador;
#Inserindo dados na tabela colaborador
insert into colaborador values (null, 'Jeovana Knoblauch', '2008-07-27', '(69) 99345-6941', 'jeovana254@gmail.com');
insert into colaborador values (null, 'Maria Liz Souza', '2007-05-14', '(69) 99666-2222', 'souzaliz23@gmail.com');
insert into colaborador values (null, 'Eduarda Nogueira', '2005-09-15', '(69) 99254-7381', 'eduarda234@gmail.com');

select * from tipo_de_sessao;
#Inserindo dados na tabela tipo de sessão
insert into tipo_de_sessao values (null,'1 hora', '250,00', '15 fotos', '2025-10-15', 'Entrega digital por link', 'Ensaio Individual');
insert into tipo_de_sessao values (null,'2 horas', '400,00', '30 fotos', '2025-10-20', 'Entrega em pendrive', 'Pré-Wedding');
insert into tipo_de_sessao values (null,'3 horas', '600,00', '50 fotos', '2025-10-25', 'Com álbum impresso', 'Aniversário');
insert into tipo_de_sessao values (null,'45 minutos', '180,00', '10 fotos', '2025-10-18', 'Entrega online', 'Corporativo');

select * from orcamento;
#Inserindo dados na tabela orçamento
insert into orcamento values (null, 'Beatriz de Oliveira', 'Jeovana Knoblauch', 'Pacote Bronze', '250,00', 'Aprovado', 'Pix', 'Ensaio Individual');
insert into orcamento values (null, 'Maria Aparecida Pereira', 'Maria Liz Souza', 'Pacote Prata', '400,00', 'Em Análise', 'Cartão de Crédito', 'Pré-Wedding');
insert into orcamento values (null, 'Maria Eduarda Silva', 'Eduarda Nogueira','Pacote Ouro', '600,00', 'Aprovado', 'Dinheiro', 'Aniversário');
insert into orcamento values (null, 'Empresa XPTO', 'Jeovana Knoblauch', 'Pacote Corporativo', '180,00', 'Pendente', 'Transferência', 'Corporativo');

select * from pacote;
#Inserindo dados na tabela pacote
insert into pacote values (null, 'Pacote Bronze', '15 fotos digitais em alta resolução', '250,00', 'Cliente', 'Padrão');
insert into pacote values (null, 'Pacote Prata', '30 fotos + pendrive personalizado', '400,00', 'Cliente', 'Personalizado');
insert into pacote values (null, 'Pacote Ouro', '50 fotos + álbum impresso', '600,00', 'Cliente', 'Luxo');
insert into pacote values (null, 'Pacote Corporativo', '10 fotos digitais para uso profissional', '180,00', 'Empresa', 'Compacto');

select * from agendamento;
#Inserindo dados na tabela agendamento
insert into agendamento values (null, 'Beatriz de Oliveira', '2025-10-15', 'Ensaio Individual', '1 hora', 'Jeovana Knoblauch', 'Sessão individual em estúdio');
insert into agendamento values (null, 'Maria Aparecida Pereira', '2025-10-20', 'Pré-Wedding', '2 horas', 'Maria Liz Souza', 'Sessão de casal ao ar livre');
insert into agendamento values (null, 'Maria Eduarda Silva', '2025-10-25', 'Aniversário', '3 horas', 'Eduarda Nogueira', 'Cobertura de aniversário');
insert into agendamento values (null, 'Empresa XPTO', '2025-10-18', 'Corporativo', '45 minutos', 'Jeovana Knoblauch', 'Fotos corporativas de equipe');

select * from pagamento;
#Inserindo dados na tabela pagamento
insert into pagamento values (null, 'Beatriz de Oliveira', 'Jeovana Knoblauch', 'Pacote Bronze', '250.00', '250.00', '0.00', 'Pix', 'Pago');
insert into pagamento values (null, 'Maria Aparecida Pereira', 'Maria Liz Souza', 'Pacote Prata', '200.00', '400.00','200.00', 'Cartão de Crédito', 'Parcial');
insert into pagamento values (null, 'Maria Eduarda Silva', 'Eduarda Nogueira', 'Pacote Ouro', '600.00', '600.00', '0.00', 'Dinheiro', 'Pago');
insert into pagamento values (null, 'Empresa XPTO', 'Jeovana Knoblauch', 'Pacote Corporativo', '0.00','180.00', '180.00', 'Transferência', 'Pendente');

