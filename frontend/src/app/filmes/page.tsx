'use client';

import Footer from "@/app/components/Footer/Footer"
import Header from "@/app/components/Header/Header" 
import { useEffect, useState } from "react"
import { api } from "@/app/services/api"
import { Filme } from "@/app/types/Filme"
import { CardFilme } from "@/app/components/CardFilme"
import Link from "next/link";


export default function Filmes() {
  const [filmes, setFilmes] = useState<Filme[]>([]);

  useEffect(() => {
    api.get<Filme[]>("/filmes").then(response => {
      setFilmes(response.data)
    });
  },
  []);
  
  return(
      <div className="bg-neutral-800 min-h-screen overflow-x-hidden">
        <Header role="admin"></Header>  
        <div className="py-20">
          <h1 className="text-2xl font-bold mb-8 px-8">
              Filmes em Cartaz
          </h1>

          <div className="grid grid-cols-1 md:grid-cols-3 gap-10 max-w-7xl mx-auto">
            {filmes.map(filme => (
              <Link key={filme.id} href={`/filmes/${filme.id}`}>
                <div className="bg-zinc-900 rounded-xl overflow-hidden hover:scale-105 transition cursor-pointer">
                  <img
                    src={`${process.env.NEXT_PUBLIC_API_URL}/uploads/${filme.imagemURL}`}
                    className="h-64 w-full object-cover"
                  />

                  <div className="p-4">
                    <h2 className="font-bold">{filme.titulo}</h2>
                    <p className="text-sm text-zinc-400">
                      {filme.duracaoMinutos} min
                    </p>
                    <span className="text-xs bg-red-600 px-2 py-1 rounded">
                      {filme.classificacao}
                    </span>
                  </div>
                </div>
              </Link>
            ))}
          </div>
        </div>
        <Footer role="admin"></Footer>
      </div>
    )
}