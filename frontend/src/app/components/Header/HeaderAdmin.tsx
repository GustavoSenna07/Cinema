import { Search } from "lucide-react";
import Button from "../Inputs/Button";

export default function HeaderAdmin() {
  return (
    <div className="flex justify-end items-center p-2 gap-4">
      <Button variant="headerbt" href="">Criar Categoria</Button>
      <Search size={30} color="black" />
    </div>
  )
}