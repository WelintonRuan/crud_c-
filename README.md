#  Sistema de Zoológico

Sistema desenvolvido em **C#** para gerenciamento de animais de um zoológico, utilizando **MySQL** como banco de dados.

O sistema funciona através de um menu no terminal e permite cadastrar, listar, buscar, atualizar e excluir animais.

---

## 👥 Integrantes

* Welinton
* Leonardo
* Yuri

---

## 🗄️ Banco de Dados Utilizado

O projeto utiliza o **MySQL**.

O banco de dados utilizado é:

```text
zoo
```

A tabela principal utilizada pelo sistema é `animais`, contendo os seguintes campos:

| Campo     | Tipo    | Descrição               |
| --------- | ------- | ----------------------- |
| `id`      | INT     | Identificador do animal |
| `nome`    | VARCHAR | Nome do animal          |
| `especie` | VARCHAR | Espécie do animal       |
| `idade`   | INT     | Idade do animal         |
| `habitat` | VARCHAR | Habitat do animal       |

---

## 📚 Biblioteca / Driver Utilizado

Para realizar a comunicação entre o C# e o MySQL foi utilizada a biblioteca:

```text
MySql.Data
```

Essa biblioteca fornece as classes necessárias para conectar o programa C# ao banco de dados MySQL.

As principais classes utilizadas no projeto são:

* `MySqlConnection` → realiza a conexão com o banco de dados.
* `MySqlCommand` → executa comandos SQL.
* `MySqlDataReader` → lê os dados retornados pelas consultas SQL.

A biblioteca é importada no código através de:

```csharp
using MySql.Data.MySqlClient;
```

---

## 📦 Como Instalar as Dependências

Primeiramente, é necessário ter o **.NET SDK** instalado no computador.

Dentro da pasta do projeto, abra o terminal e execute:

```bash
dotnet add package MySql.Data
```

Esse comando instala o pacote `MySql.Data`, necessário para que o C# consiga se comunicar com o MySQL.

Para verificar se o pacote foi instalado, também é possível utilizar:

```bash
dotnet list package
```

---

## ⚙️ Como Configurar o Banco de Dados

Primeiramente, é necessário ter o **MySQL Server** instalado e funcionando.

Crie o banco de dados:

```sql
CREATE DATABASE zoo;
```

Depois, selecione o banco:

```sql
USE zoo;
```

Crie a tabela `animais`:

```sql
CREATE TABLE animais (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    especie VARCHAR(100) NOT NULL,
    idade INT NOT NULL,
    habitat VARCHAR(100) NOT NULL
);
```

### 🔌 Configuração da conexão

No arquivo principal do projeto, a conexão está configurada da seguinte maneira:

```csharp
string connectionString = "Server=localhost;Database=zoo;Uid=root;Pwd=Senac2026;";
```

Essa string informa ao programa:

* `Server=localhost` → o MySQL está sendo executado no próprio computador.
* `Database=zoo` → banco de dados que será utilizado.
* `Uid=root` → usuário utilizado para acessar o MySQL.
* `Pwd=Senac2026` → senha do usuário do MySQL.

**Importante:** caso o usuário, senha ou endereço do MySQL sejam diferentes no computador, é necessário alterar esses valores na `connectionString`.

---

## ▶️ Como Executar o Projeto

Depois de instalar as dependências e configurar o banco de dados, abra o terminal na pasta do projeto.

Para executar:

```bash
dotnet run
```

O sistema apresentará um menu semelhante a:

```text
SISTEMA DE ZOOLOGICO
1- Cadastrar animal
2- Listar animais
3- Buscar animal
4- Atualizar animal
5- Excluir animal
0- Sair
```

Cada opção executa uma operação diferente:

### 1 - Cadastrar animal

Permite inserir um novo animal no banco de dados, informando:

* Nome
* Espécie
* Idade
* Habitat

O sistema utiliza um comando `INSERT` para salvar os dados.

### 2 - Listar animais

Busca todos os animais cadastrados utilizando um comando `SELECT` e apresenta os resultados no terminal.

### 3 - Buscar animal

Permite pesquisar um animal através do seu `ID`.

### 4 - Atualizar animal

Permite alterar os dados de um animal existente através do seu `ID`.

### 5 - Excluir animal

Remove um animal do banco de dados através do seu `ID`.

### 0 - Sair

Encerra a execução do sistema.

---

## 🔗 Como Funciona a Conexão com o MySQL

A conexão entre o C# e o MySQL acontece através da biblioteca `MySql.Data`.

Primeiramente, o programa possui uma **string de conexão**, que informa os dados necessários para acessar o banco:

```csharp
string connectionString = "Server=localhost;Database=zoo;Uid=root;Pwd=Senac2026;";
```

Essa string é enviada para a classe `GerenciadorZoo`:

```csharp
GerenciadorZoo banco = new
```
