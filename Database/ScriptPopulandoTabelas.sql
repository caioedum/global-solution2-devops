-- Usuários
INSERT INTO Usuario (nome, email, senha_hash, nivel_acesso, status)
VALUES 
('João Silva', 'joao.silva@email.com', 'hashsenha1', 'admin', 'ativo'),
('Maria Souza', 'maria.souza@email.com', 'hashsenha2', 'operador', 'ativo'),
('Carlos Lima', 'carlos.lima@email.com', 'hashsenha3', 'operador', 'inativo');

-- Áreas de Risco
INSERT INTO AreaRisco (nome_area, descricao, latitude, longitude, status, raio_cobertura)
VALUES
('Zona Norte', 'Área industrial com risco de incêndio', -23.5505, -46.6333, 'ativo', 2.50),
('Centro', 'Região central com alto fluxo de pessoas', -23.5610, -46.6550, 'ativo', 1.75),
('Zona Sul', 'Área residencial próxima a mata', -23.6000, -46.7000, 'inativo', 3.00);

-- Drones
INSERT INTO Drone (nome, modelo, status, latitude, longitude, bateria, capacidade_carga, data_ultima_manutencao, horario_operacao)
VALUES
('Drone Alpha', 'DJI Mavic 2', 'ativo', -23.5505, -46.6333, 85, 1.50, '2025-05-20 10:00:00', '08:00-18:00'),
('Drone Beta', 'Parrot Anafi', 'manutencao', -23.5610, -46.6550, 40, 1.20, '2025-05-15 09:30:00', '09:00-17:00'),
('Drone Gamma', 'DJI Phantom 4', 'ativo', -23.6000, -46.7000, 100, 2.00, '2025-06-01 11:00:00', '07:00-19:00');

-- Alertas
INSERT INTO Alerta (tipo_alerta, status, id_area, id_drone, id_usuario, gravidade, descricao)
VALUES
('Incêndio', 'pendente', 1, 1, 1, 'alto', 'Fumaça detectada na área industrial'),
('Aglomeração', 'resolvido', 2, 2, 2, 'médio', 'Grande fluxo de pessoas no centro'),
('Invasão', 'pendente', 3, 3, 3, 'baixo', 'Movimentação suspeita próxima à mata');
