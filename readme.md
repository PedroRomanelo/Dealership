IUsuarioRepository  ←──── contrato (o quê)
       ↑
UsuarioRepository   ←──── implementação (o como) + herda BaseRepository

IUsuarioService     ←──── contrato
       ↑
UsuarioService      ←──── injeta IUsuarioRepository (nunca a classe concreta)

UsuariosController  ←──── injeta IUsuarioService

## referencias
- https://www.youtube.com/watch?v=4cMe8MaRXes&t=584s