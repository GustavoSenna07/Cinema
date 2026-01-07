import CategoriasAdmin from "./CategoriasAdmin"
import CategoriasUser from "./CategoriasUser"
import Movies from "../Movies"

type CategoriaProps = {
  role?: "user" | "admin"
}

export default function Categorias({role}:CategoriaProps) {
  return (
    <div className="w-full h-full p-2">
      {role === "admin" ? <CategoriasAdmin/> : <CategoriasUser/>}
      <div className="flex overflow-x-auto gap-4 scrollbar-hidden overflow-y-hidden">
        <Movies titleMovie="Vai toma no cu piranha" imageUrlMovie="/Gru.png" variant="category"/>
        <Movies titleMovie="Romance lindo" imageUrlMovie="/jose-safado.jpg" variant="category"/>
        <Movies titleMovie="Romance lindo" imageUrlMovie="/jose-safado.jpg" variant="category"/>
        <Movies titleMovie="Romance lindo" imageUrlMovie="/jose-safado.jpg" variant="category"/>
        <Movies titleMovie="Romance lindo" imageUrlMovie="/jose-safado.jpg" variant="category"/>
        <Movies titleMovie="Romance lindo" imageUrlMovie="/jose-safado.jpg" variant="category"/>
        <Movies titleMovie="Romance lindo" imageUrlMovie="/jose-safado.jpg" variant="category"/>
        <Movies titleMovie="Romance lindo" imageUrlMovie="/jose-safado.jpg" variant="category"/>

      </div>
    </div>
  )
}