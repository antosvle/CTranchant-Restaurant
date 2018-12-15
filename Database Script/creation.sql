CREATE TABLE Ingredients(
        id   Int  IDENTITY  NOT NULL ,
        name Varchar (50) NOT NULL
        ,CONSTRAINT Ingredients_PK PRIMARY KEY (id)
);

CREATE TABLE Recipes(
        id          Int  IDENTITY  NOT NULL ,
        category    Varchar (50) NOT NULL CHECK (category IN('entree', 'plat', 'dessert')) ,
        name        Varchar (50) NOT NULL ,
        nb_people          Int NOT NULL ,
        speciality  Varchar (50) NOT NULL CHECK (speciality IN('sauces', 'rotisserie', 'poisson', 'entremets', 'garde-manger', 'patisserie')) ,
        description Text NOT NULL
        ,CONSTRAINT Recipes_PK PRIMARY KEY (id)
);

CREATE TABLE Tablewares(
        id       Int  IDENTITY  NOT NULL ,
        name     Varchar (50) NOT NULL ,
        quantity Int NOT NULL
        ,CONSTRAINT Tablewares_PK PRIMARY KEY (id)
);

CREATE TABLE Logs(
        id      Int  IDENTITY  NOT NULL ,
        date    Date NOT NULL ,
        source  Varchar (50) NOT NULL ,
        message Text NOT NULL
        ,CONSTRAINT Logs_PK PRIMARY KEY (id)
);

CREATE TABLE TableInfo(
        id          Int  IDENTITY  NOT NULL ,
        nb_people   Int NOT NULL ,
        table_x     Float NOT NULL ,
        table_y     Float NOT NULL ,
        row_y     Float NOT NULL ,
        isOccupied  Bit NOT NULL 
        ,CONSTRAINT TableInfo_PK PRIMARY KEY (id)
);

CREATE TABLE Furniture(
        id       Int  IDENTITY  NOT NULL ,
        name     Varchar (50) NOT NULL ,
        quantity Int NOT NULL
        ,CONSTRAINT Furniture_PK PRIMARY KEY (id)
);

CREATE TABLE Utensils(
        id       Int  IDENTITY  NOT NULL ,
        name     Varchar (50) NOT NULL ,
        quantity Int NOT NULL
        ,CONSTRAINT Utensils_PK PRIMARY KEY (id)
);

CREATE TABLE Tasks(
        id          Int  IDENTITY  NOT NULL ,
        time        Int NOT NULL ,
        description Text NOT NULL ,
        step             Int NOT NULL ,
        recipe_fk        Int NOT NULL ,
        furniture_fk     Int NOT NULL
        ,CONSTRAINT Tasks_PK PRIMARY KEY (id)

        ,CONSTRAINT Tasks_Recipes_FK FOREIGN KEY (recipe_fk) REFERENCES Recipes(id)
        ,CONSTRAINT Tasks_Furniture0_FK FOREIGN KEY (furniture_fk) REFERENCES Furniture(id)
);

CREATE TABLE Task_utensil(
        id Int NOT NULL ,
        task_fk    Int NOT NULL
        ,CONSTRAINT Task_utensil_PK PRIMARY KEY (id,task_fk)

        ,CONSTRAINT Task_utensil_Utensils_FK FOREIGN KEY (id) REFERENCES Utensils(id)
        ,CONSTRAINT Task_utensil_Tasks0_FK FOREIGN KEY (task_fk) REFERENCES Tasks(id)
);

CREATE TABLE Recipe_ingredient(
        recipe_id           Int NOT NULL ,
        ingredient_id       Int NOT NULL ,
        quantite_ingredient Int NOT NULL
        ,CONSTRAINT Recipe_ingredient_PK PRIMARY KEY (recipe_id,ingredient_id)

        ,CONSTRAINT Recipe_ingredient_Recipes_FK FOREIGN KEY (recipe_id) REFERENCES Recipes(id)
        ,CONSTRAINT Recipe_ingredient_Ingredients0_FK FOREIGN KEY (ingredient_id) REFERENCES Ingredients(id)
);

