create table category
(
    id   serial primary key,
    name text
);

create table product
(
    id   serial primary key,
    name text
);

create table category__product
(
    category_id int references category (id),
    product_id  int references product (id),
    primary key (category_id, product_id)
);

insert into "category" (name)
values ('молочные продукты'),
       ('бытовые товары'),
       ('мясные продукты'),
       ('акция'),
       ('местный производитель');

insert into "product" (name)
values ('молоко'),
       ('освежитель воздуха'),
       ('цыпленок гриль'),
       ('вода');

insert into "category__product" (category_id, product_id)
values (1, 1),
       (4, 1),
       (5, 1),
       (2, 2),
       (5, 2),
       (3, 3);