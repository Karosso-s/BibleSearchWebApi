# Web-API em C# para o back-end do projeto BibleSearch.

Esta WebAPI utiliza C# para desenvolver uma busca parametrizada e outra busca elastica em dois tipos de banco de dados diferentes.

O banco de dados foi desenvolvido em SQL Server e consiste em diferentes versões da bíblia, e para cada versão existe uma lista invertida, com as palavras (acima de 2 caracteres, a fim remover artigos e pronomes) contidas na bíblia e suas respectivas posições.

Já foram implementados:

1. O algoritmo de busca parametrizada, que busca por livro, capitulo e versiculos.
2. O algoritmo de busca elástica, que faz a busca do índice dos versículos numa lista invertida e retorna a interseção dos índices como resultado.
3. A integração com o dicio-API do ThiagoNelsi (https://github.com/ThiagoNelsi/dicio-api), que retorna sinônimos das palavras, que são utilizadas para aumentar a performance da busca elástica.
4. A web-API para retornar os resultados em Json.

Serão Implementados:

1. Criação de um banco de dados de sinônimos, para substituir a dicio-API e otimizar a busca elástica.
2. Criação de um banco de dados de plurais para otimizar a busca elástica.
3. Criação de um banco de dados de conjugações verbais para otimizar a busca elástica.

----

Repositório aberto a qualquer tipo de sugestões e críticas.
