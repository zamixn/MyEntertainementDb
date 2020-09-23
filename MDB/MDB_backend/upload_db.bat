:: export local db
mysqldump -u root -h localhost edb > tmp_db_export.sql
:: delete remote db
mysql -u b59f90003a14e0 -h eu-cdbr-west-03.cleardb.net -p%clear_db_pass% heroku_2e5033e7d22fe9f < delete_db.sql
:: upload exported local db to remote db
mysql -u b59f90003a14e0 -h eu-cdbr-west-03.cleardb.net -p%clear_db_pass% heroku_2e5033e7d22fe9f < tmp_db_export.sql