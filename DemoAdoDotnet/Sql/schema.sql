-- Base créée dans l'administration alwaysdata ; script exécuté dans phpMyAdmin
CREATE TABLE categorie (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nom VARCHAR(50) NOT NULL UNIQUE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE produit (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nom VARCHAR(100) NOT NULL,
	prix DECIMAL(10,2) NOT NULL,
	quantite INT NOT NULL DEFAULT 0,
	date_ajout DATE NULL,
	categorie_id INT NOT NULL,
	CONSTRAINT fk_produit_categorie FOREIGN KEY (categorie_id) REFERENCES categorie(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO categorie (nom) VALUES ('Informatique'), ('Audio');

INSERT INTO produit (sku, nom, prix, quantite, date_ajout, categorie_id)
VALUES ('CLV-01', 'Clavier', 49.99, 12, '2026-01-15', 1),
('SRS-02', 'Souris', 19.99, 0, NULL, 1),
('CSQ-03', 'Casque', 129.00, 5, '2026-02-03', 2);