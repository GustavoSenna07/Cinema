"use client";

import { useEffect, useState } from "react";
import { useParams } from "next/navigation";
import { api } from "@/app/services/api";
import Header from "@/app/components/Header/Header";


export default function FilmeDetalhes() {
  const { id } = useParams();
  const [filme, setFilme] = useState<any>(null);

  useEffect(() => {
    api.get(`/filmes/${id}`).then(res => {
      setFilme(res.data);
    });
  }, [id]);

  if (!filme) {
    return (
      <div className="min-h-screen bg-neutral-900 text-white flex items-center justify-center">
        Carregando...
      </div>
    );
  }

  return (
    <div className="bg-neutral-800 w-screen mx-auto min-h-screen overflow-x-hidden flex items-center">
      <Header role="user" />
      <div className="p-6 pt-20 w-[500px] bg-amber-300">
        <img
          src={`http://localhost:5006/uploads/${filme.imagemURL}`}
          alt={filme.titulo}
          className="rounded-sm h-[500px]"
        />
        <h1 className="text-3xl font-bold mb-4">{filme.titulo}</h1>
        <p>{filme.classificacao}</p>
      </div>
      

      <div className="bg-[rgba(66,66,66,1)] mt-20">
        <p><strong>Gênero:</strong> {filme.genero}</p>
        <p><strong>Duração:</strong> {filme.duracaoMinutos} min</p>
        
        <p><strong>Diretor:</strong> {filme.diretor}</p>
        <p><strong>Estúdio:</strong> {filme.estudio}</p>
        <p className="mt-4">{filme.sinopse}</p>
      </div>
    </div>
  );
}
