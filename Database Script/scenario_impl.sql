
#Salade de cabilaud
INSERT INTO [dbo].[Recipe_ingredient] VALUES (9, 5, 4);
INSERT INTO [dbo].[Recipe_ingredient] VALUES (9, 7, 1);
INSERT INTO [dbo].[Recipe_ingredient] VALUES (9, 32, 1);
INSERT INTO [dbo].[Recipe_ingredient] VALUES (9, 44, 3);

INSERT INTO [dbo].[Tasks] VALUES(30, 'cuire le cabilaud', 1, 9, 1)
INSERT INTO [dbo].[Tasks] VALUES(15, 'assaisonner la salade', 2, 9, 4)
INSERT INTO [dbo].[Tasks] VALUES(10, 'ajouter le cabilaud', 3, 9, 4)

INSERT INTO [dbo].[Task_utensil] VALUES(1,6)
INSERT INTO [dbo].[Task_utensil] VALUES(2,7)


#Burger Maison
INSERT INTO [dbo].[Recipe_ingredient] VALUES (12, 11, 2);
INSERT INTO [dbo].[Recipe_ingredient] VALUES (12, 5, 4);
INSERT INTO [dbo].[Recipe_ingredient] VALUES (12, 9, 2);
INSERT INTO [dbo].[Recipe_ingredient] VALUES (12, 10, 2);
INSERT INTO [dbo].[Recipe_ingredient] VALUES (12, 8, 1);
INSERT INTO [dbo].[Recipe_ingredient] VALUES (12, 3, 3);

INSERT INTO [dbo].[Tasks] VALUES(10, 'cuire le steak haché', 1, 12, 1)
INSERT INTO [dbo].[Tasks] VALUES(10, 'ajouter la sauce sur le pain a burger et le frommage', 2, 12, 4)
INSERT INTO [dbo].[Tasks] VALUES(10, 'mettre au four le burger', 3, 12, 2)
INSERT INTO [dbo].[Tasks] VALUES(10, 'couper les pommes de terres', 4, 12, 4)
INSERT INTO [dbo].[Tasks] VALUES(10, 'cuire les frites', 5, 12, 1)

#Gigot d agneau
INSERT INTO [dbo].[Recipe_ingredient] VALUES (19, 3, 4);
INSERT INTO [dbo].[Recipe_ingredient] VALUES (19, 6, 30);
INSERT INTO [dbo].[Recipe_ingredient] VALUES (19, 21, 1);

INSERT INTO [dbo].[Tasks] VALUES(20, 'préparer et assaisonner le gigot', 1, 19, 4)
INSERT INTO [dbo].[Tasks] VALUES(50, 'cuire le Gigot', 2, 19, 2)
INSERT INTO [dbo].[Tasks] VALUES(10, 'découper le Gigot', 3, 19, 4)

INSERT INTO [dbo].[Task_utensil] VALUES(3,11)


#Tarte aux pommes
INSERT INTO [dbo].[Recipe_ingredient] VALUES (25, 1, 6);
INSERT INTO [dbo].[Recipe_ingredient] VALUES (25, 40, 1);

INSERT INTO [dbo].[Tasks] VALUES(30, 'couper et placer les pommes', 1, 25, 4)
INSERT INTO [dbo].[Tasks] VALUES(40, 'cuire la tarte', 2, 25, 2)
INSERT INTO [dbo].[Tasks] VALUES(10, 'couper la tarte', 3, 25, 4)

INSERT INTO [dbo].[Task_utensil] VALUES(3,12)
INSERT INTO [dbo].[Task_utensil] VALUES(3,14)

#Flan coco
INSERT INTO [dbo].[Recipe_ingredient] VALUES (30, 39, 2);
INSERT INTO [dbo].[Recipe_ingredient] VALUES (30, 41, 1);
INSERT INTO [dbo].[Recipe_ingredient] VALUES (30, 40, 1);
INSERT INTO [dbo].[Recipe_ingredient] VALUES (30, 25, 3);

INSERT INTO [dbo].[Tasks] VALUES(15, 'preparer la pate', 1, 30, 4)
INSERT INTO [dbo].[Tasks] VALUES(30, 'cuire la pate', 2, 30, 2)
INSERT INTO [dbo].[Tasks] VALUES(10, 'presenter le flan', 3, 30, 4)

INSERT INTO [dbo].[Task_utensil] VALUES(2,15)
INSERT INTO [dbo].[Task_utensil] VALUES(3,17)