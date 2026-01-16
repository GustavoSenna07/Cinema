import { Link } from "react-router-dom";
import { Filme } from "../types/Filme";
import { API_URL } from "../services/api";

interface Props {
  filme: Filme;
}

export function CardFilme({ filme }: Props) {
  return(
    <Link to={`/filmes/${filme.id}`}>
      <div className="bg-zinc-900 rounded-2xl overflow-hidden hover:scale-105 hover:shadow-2xl hover:shadow-black/50 transition-all duration-300 cursor-pointer">
  <img
    src={`${process.env.NEXT_PUBLIC_API_URL}/uploads/${filme.imagemURL}`}
    alt={filme.titulo}
    className="h-[420px] w-full object-cover"
  />

  <div className="p-6">
    <h2 className="text-xl font-bold mb-2">
      {filme.titulo}
    </h2>

    <p className="text-sm text-zinc-400 mb-3">
      {filme.duracaoMinutos} min
    </p>

    <span className="inline-block text-sm bg-red-600 px-3 py-1 rounded-full">
      {filme.classificacao}
    </span>
  </div>
</div>

    </Link>
  )
}