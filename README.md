# 📚 LIVRARIA 5by5

Sistema de gerenciamento de biblioteca em C#, utilizando arquivos `.txt` para persistência de dados.

---

## 📁 Estrutura do Projeto

- **Library**: Classe principal que armazena os livros.
- **Behavior**: Contém os métodos para adicionar, listar, atualizar e remover livros.
- **FileManipulation**: Responsável por criar diretórios, ler e salvar dados em arquivos.
- **livros.txt**: Arquivo onde os livros são armazenados.

---

## ✅ Funcionalidades

- 📖 **Adicionar Livro**  
  Insere um novo livro na biblioteca e atualiza o arquivo.

- 📚 **Listar Livros**  
  Exibe todos os livros cadastrados no sistema.

- ✏️ **Atualizar Livro**  
  Permite modificar as informações de um livro existente.

- ❌ **Remover Livro**  
  Exclui um livro da biblioteca e reflete a alteração no arquivo.

- 💾 **Persistência de Dados**  
  Os dados são carregados do arquivo `livros.txt` e salvos ao sair.

---

## 🧭 Menu Principal

Durante a execução, o sistema apresenta o seguinte menu interativo no console:

LIVRARIA 5by5
1 - Adicionar Livro 
2 - Listar livros
3 - Atualizar livro
4 - Remover livro
0 - Sair
