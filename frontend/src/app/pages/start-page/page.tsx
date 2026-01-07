import Header from "@/app/components/Header/Header"
import Footer from "@/app/components/Footer/Footer"
import Categorias from "@/app/components/Categorias/Categorias"

export default function StartPage() {
  return (
    <div className="bg-neutral-800 w-screen h-screen">
      <Header role="admin"></Header>
      
      <div className="pt-[60] flex justify-center items-center px-20">
        <Categorias />
      </div>

      <Footer role="admin"></Footer>
    </div>
  )
}