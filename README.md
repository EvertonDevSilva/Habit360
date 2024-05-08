# Habit360
- API para gerenciamento de hábitos do dia a dia.

## Funcionalidades
- **Criação de hábitos:** Permite a criação de hábitos a serem iniciados ou abandonados.
- **Listagem de hábitos:** Lista todos os hábitos disponíveis.
- **Atualização de hábitos:** Permite atualizar detalhes de um hábito específico.
- **Deleção de hábitos:** Permite remover hábitos que não são mais necessários ou foram abandonados.

## Tecnologias Utilizadas
- .NetCore 8.0
- C#
- EntityFamework
- SqLite

## Como Instalar via terminal
1. Clone o repositório para sua máquina local em uma pasta de sua escolha:
   - Abra o cmd, entre na pasta criada para o projeto e clone com o código abaixo
   - git clone https://github.com/EvertonDevSilva/Habit360.git
2. Restaure os pacotes NuGet:
   - dotnet restore
3. Execute as migrações para criar o banco de dados
   - dotnet tool install --global dotnet-ef
   - dotnet ef database update
4. Inicie a aplicação:
   - dotnet watch
5. Testar com swagger
   
## Como Usar via postman, insomnia, etc
  - Aqui estão alguns exemplos de comandos que você pode usar para interagir com a API usando curl:
  - curl -X POST -H "Content-Type: application/json" -d "{\"name\": \"description\", \"habitType\": \"startDate\": \"frequency\"}"
  - curl http://localhost:5000/api/tasks

## Autor
- Everton da Silva
