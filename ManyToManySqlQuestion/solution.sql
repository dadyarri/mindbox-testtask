select p.name, c.name
from category as c
         right join category__product cp on c.id = cp.category_id
         right join product p on p.id = cp.product_id;
