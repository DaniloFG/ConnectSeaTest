# 🚢 Sistema de Logística Portuária  

[![Angular](https://img.shields.io/badge/Angular-20-DD0031?logo=angular&logoColor=white)](https://angular.io/)  
[![TailwindCSS](https://img.shields.io/badge/TailwindCSS-3-38B2AC?logo=tailwind-css&logoColor=white)](https://tailwindcss.com/)  
[![.NET](https://img.shields.io/badge/.NET-8-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)  
[![Swagger](https://img.shields.io/badge/Swagger-UI-85EA2D?logo=swagger&logoColor=black)](https://swagger.io/)  

Um sistema moderno e elegante para **gestão de manifestos, escalas e vínculos entre eles**, com visualizações gráficas e backend robusto.  

---

## 🖥️ Frontend

- Desenvolvido em **Angular 20**  
- Estilização com **TailwindCSS**  
- Componentes modernos e responsivos  

### 🔧 Instalação & Execução

```bash
cd frontend-angular
npm install
npm start
```

📊 Telas do Frontend

exemplo: teste@email.com, qualquerSenha

![Login](./login.png)
![Sidebar](./sidebar.png)

📄 Consulta de Manifestos

![Consulta de Manifestos](./consulta-manifestos.png)

⚓ Consulta de Escalas

![Consulta de Escalas](./consulta-escalas.png)

🔗 Consulta de Manifestos x Escalas

![Consulta de Vinculados](./consulta-vinculados.png)

🔗 Criação de Manifestos x Escalas

![Criar Vínculo](./criar-vinculo.png)

📈 Dashboard de Gráficos

![Dashboard de Gráficos](./dashboard-graficos.png)

Visualização gráfica da correlação entre Manifestos, Escalas e Vínculos.


## ⚙️ Backend

- Criado com .NET 8
- Banco de dados em Entity Framework InMemory (sem necessidade de setup adicional)

### 🔧 Execução

```bash
cd backend-microservice1
cd ConnectSeaMs1
dotnet run
```

API documentada com Swagger

🌐 Swagger Principal

✨ Destaques do Projeto

🧩 Arquitetura modular e organizada

🎨 UI moderna e responsiva

⚡ Backend leve e performático

📊 Visualização clara dos relacionamentos

🚀 Fácil de instalar e rodar

📌 Estrutura de Imagens no Projeto

![Swagger Backend](./swagger-backend.png)

## ⚙️ Testes no Backend com XUnit

- Teste unitário
- Teste de integração
- Teste End-To-End

###

```bash
dotnet test
```
📌 Estrutura de Imagens dos Testes

![Swagger Backend](./testes.png)

## Build e Deploy no Kubernetes

Para criar as imagens Docker do backend e frontend e aplicar os manifestos no Kubernetes, siga os comandos abaixo na pasta raiz:

```bash
# Build da imagem do backend
docker build -t connectseams1api:1.0 ./backend-microservice1

# Build da imagem do frontend
docker build -t frontend-angular:1.0 ./frontend-angular/connect-sea-ui

# Aplicando os manifestos do backend
kubectl apply -f backend-microservice1/k8s/

# Aplicando os manifestos do frontend
kubectl apply -f frontend-angular/connect-sea-ui/k8s/
```

Acessando a aplicação


Frontend: disponível em http://localhost:30082

