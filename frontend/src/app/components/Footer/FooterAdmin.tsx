import Link from "next/link";

export default function FooterAdmin () {
  return (
    <div className="flex justify-center items-center gap-50">
      <Link href="/start-page">
        <h1 className="font-bold text-[rgba(182,80,250,1)] text-shadow-lg text-2xl p-2 flex justify-center 
        items-center hover:text-purple-400 hover:drop-shadow-[0_0_12px_rgba(168,85,247,0.6)]">       
          Inicio
        </h1>
      </Link>

      <Link href="/filmes">
        <h1 className="font-bold text-[rgba(182,80,250,1)] text-shadow-lg text-2xl p-2 flex justify-center 
        items-center hover:text-purple-400 hover:drop-shadow-[0_0_12px_rgba(168,85,247,0.6)]">       
          Filmes
        </h1>
      </Link>

      <Link href="">
        <h1 className="font-bold text-[rgba(182,80,250,1)] text-shadow-lg text-2xl p-2 flex justify-center 
        items-center hover:text-purple-400 hover:drop-shadow-[0_0_12px_rgba(168,85,247,0.6)]">       
          Sessões
        </h1>
      </Link>

      <Link href="/pages/start-page">
        <h1 className="font-bold text-[rgba(182,80,250,1)] text-shadow-lg text-2xl p-2 flex justify-center 
        items-center hover:text-purple-400 hover:drop-shadow-[0_0_12px_rgba(168,85,247,0.6)]">       
          Salas
        </h1>
      </Link>

      <Link href="/pages/start-page">
        <h1 className="font-bold text-[rgba(182,80,250,1)] text-shadow-lg text-2xl p-2 flex justify-center 
        items-center hover:text-purple-400 hover:drop-shadow-[0_0_12px_rgba(168,85,247,0.6)]">       
          Comida
        </h1>
      </Link>
    </div>
  )
}