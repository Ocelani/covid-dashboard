# Notas:

Primeira implementação do modelo Country leva em consideração apenas Id e Nome. Seria interessante implementar outras propriedades depois, e usar tabelas para popular o banco, como:

* https://developers.google.com/public-data/docs/canonical/countries_csv
* https://www.worlddata.info/downloads/

Seria interessante também utilizar a string código país como primary key (ex: BR).

* https://stackoverflow.com/questions/32983524/how-to-use-string-property-as-primary-key-in-entity-framework

ou pelo menos garantir a unicidade do país de outra maneira.





Modificar a relação entre país e status para garantir que seja um-para-um:

* Tentei usar um atributo Status em Country e deu pau.
* Atributo numérico "status" ficou sobrando.



View:

* Pensei da home ter a tabela principal e pronto. Pra fazer isso, tem que corrigir as coisas de countryId, e garantir que a relação é 1-1 e os atributos são únicos.
* Além da home, acho que pode deixar a aba countries, e talvez um about com informações do trabalho, puc etc. Acho que é bom pra ficar organizado.



Authentication:

Admin:

* email: admin@admin
* senha: Admin@1



(precisa logar para aparecerem as opções de editar/criar/deletar)

--------

Acredito que ao corrigir alguns dos pontos acima, ao modificar o banco de dados, seja necessário repetir algumas modificações (como por exemplo nas views). Então é bom ficar atento e comparar os códigos.cd