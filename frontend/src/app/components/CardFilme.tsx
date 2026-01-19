import Link from "next/link";
import { Filme } from "../types/Filme";
import { API_URL } from "../services/api";

interface Props {
  filme: Filme;
}

function normalizarClassificacao(classificacao: string) {
  const value = classificacao.trim().toUpperCase();

  if (value === "L" || value === "LIVRE") return "L";
  if (value === "10") return "10";
  if (value === "12") return "12";
  if (value === "14") return "14";
  if (value === "16") return "16";
  if (value === "18") return "18";

  return "N/A";
}


function getClassificacaoColor(classificacao: string) {
  switch (classificacao) {
    case "L":
      return "bg-green-600 text-white";
    case "10":
      return "bg-blue-600 text-white";
    case "12":
      return "bg-yellow-500 text-black";
    case "14":
      return "bg-orange-500 text-white";
    case "16":
      return "bg-red-600 text-white";
    case "18":
      return "bg-black text-white";
    default:
      return "bg-zinc-600 text-white";
  }
}


export function CardFilme({ filme }: Props) {
  const classificacaoNormalizada = normalizarClassificacao(filme.classificacao);
  return(
    <Link href={`/filmes/${filme.id}`}>
      <div className="bg-zinc-900 rounded-lg overflow-hidden hover:scale-105 hover:shadow-2xl hover:shadow-black/50 transition-all duration-300 cursor-pointer">
  <img
    src={`${process.env.NEXT_PUBLIC_API_URL}/uploads/${filme.imagemURL}`}
    alt={filme.titulo}
    className="h-[300px] w-full object-cover"
  />

  <div className="p-6">
    <h2 className="text-xl font-bold mb-2">
      {filme.titulo}
    </h2>

    <p className="text-sm text-zinc-400 mb-3">
      {filme.duracaoMinutos} min
    </p>

    

  <span
    className={`text-xs px-3 py-1 rounded-sm uppercase tracking-wide font-bold ${getClassificacaoColor(classificacaoNormalizada)}`}>
    {classificacaoNormalizada}
  </span>


  </div>
</div>

    </Link>
  )
}