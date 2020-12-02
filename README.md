# Question 1
end point 
[Get Method]
example:
https://localhost:5001/api/manufacturer/?CostPrice=123&SellPrice=321&Inventory=1

Output: 
int

# Question 2
end point 
[Post Method]
example:
https://localhost:5001/api/csv/csv?Name=test&file=

csv file
FirstName, LastName
Michael, Jordan
Christian, Ronaldo ..etc

Output: 
Frodo Baggins
Bill Gates
Steve Jobs ..etc

# Question 3
end point 
[Get Method]
example:
https://localhost:5001/api/lottery/generateluckynumber?inputNumber=120888

Output: 
[ "000088" , "000188" , "000288", ..etc ]

# Question 4
end point 
[Get Method]
example:
https://localhost:5001/api/lottery/generateluckynumber?inputNumber=120888

Output: 
[[1,2,0,8,8,8],[1,2,0,8,8,8],..etc]

# Question 5
create users table:
create table users(id integer primary key,
name text not null unique);

insert users into table:
INSERT INTO users (name)VALUES ('Rick'), ('John'), ('Zing'), ('Nan');

create users cars:
create table cars(id integer primary key,
model text not null unique);

insert cars into table:
INSERT INTO cars (model)VALUES ('Corvette Z06'), ('Lotus Exite S'), ('BMW M3'), ('BMW 320d'), ('Mercedes SLK AMG'), ('Toyota Alphard'), ('Toyota Camry'), ('Porsche 911'), ('BMW M5'), ('Jaguar'), ('Mini Cooper'), ('TukTuk'),('Honda Jazz');

create users_cars table:
create table users_cars(user_id integer not null,
car_id integer not null);

INSERT INTO cars (user_id, car_id)
VALUES (1, 1), (1, 2), (1, 3), (2, 4), (2, 5),(3, 6),(3, 7),(4, 8),(4, 10),(4, 11),(4, 12),(4, 13),(4, 14)

# Question 6
SELECT users.name, COUNT(users_cars.user_id) AS users FROM users_cars
    INNER JOIN cars ON cars.id = users_cars.car_id
    INNER JOIN users ON users.id = users_cars.user_id

# Question 7
SELECT users.name, COUNT(users_cars.user_id) AS users FROM users_cars
    INNER JOIN cars ON cars.id = users_cars.car_id
    INNER JOIN users ON users.id = users_cars.user_id
    GROUP BY users.name
HAVING COUNT(users_cars.user_id) > 1; 
