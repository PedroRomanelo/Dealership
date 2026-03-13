IUsuarioRepository  ←──── contrato (o quê)
       ↑
UsuarioRepository   ←──── implementação (o como) + herda BaseRepository

IUsuarioService     ←──── contrato
       ↑
UsuarioService      ←──── injeta IUsuarioRepository (nunca a classe concreta)

UsuariosController  ←──── injeta IUsuarioService