# BibleSearchWebApi

Este projeto serve para fazer buscas de versículos bíblicos. Para isto ele utiliza Elastic Search para buscar versículos que contenham as palavras determinadas na busca.

O banco de dados foi desenvolvido em SQL Server e consiste em diferentes versões da bíblia, e para cada versão existe uma lista invertida, com as palavras (acima de 2 caracteres, a fim remover artigos e pronomes) contidas na bíblia e suas respectivas posições.

Para acesso ao banco de dados utilizasse uma web API, desenvolvida em C#, que é capas de retornar duas buscas, uma, a busca por parâmetros, que retorna uma pesquisa por, livro, capitulo e versículo(s), e outra, a busca elástica, que faz a interseção das posições de cada palavra contida na busca.

Para melhorar o resultado da busca, utilizou-se a dicio-API do ThiagoNelsi (https://github.com/ThiagoNelsi/dicio-api), que retorna vários sinônimos de cada palavra buscada, para melhorar os resultados da busca elástica.
O front-end está sendo desenvolvido em Angular, e consiste em uma barra de pesquisa para a busca elástica, e uma busca por parâmetros para a busca por livro, capito e versículos.

Planos Futuros:
1 - Desenvolver um dicionario de conjugação verbal
2 - Desenvolver um dicionario de plurais
3 - Desenvolver uma aplicação front-end que configure uma imagem com um versiculo para ser comporatilhado entre as redes sociais.
