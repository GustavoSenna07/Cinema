"use client";

import { useEffect, useState } from "react";
import { useParams } from "next/navigation";
import { api } from "@/app/services/api";


export default function FilmeDetalhes() {
  const { id } = useParams();
  const [filme, setFilme] = useState<any>(null);

  useEffect(() => {
    api.get(`/filmes/${id}`).then(res => {
      setFilme(res.data);
    });
  }, [id]);

  if (!filme) {
    return <p className="p-6">Carregando...</p>;
  }

  return (
    <div className="p-6 max-w-5xl mx-auto grid md:grid-cols-2 gap-6">
      <img
        src={`http://localhost:5006/uploads/${filme.imagemURL}`}
        alt={filme.titulo}
        className="rounded-xl"
      />

      <div>
        <h1 className="text-3xl font-bold mb-4">{filme.titulo}</h1>

        <p><strong>Gênero:</strong> {filme.genero}</p>
        <p><strong>Duração:</strong> {filme.duracaoMinutos} min</p>
        <p><strong>Classificação:</strong> {filme.classificacao}</p>
        <p><strong>Diretor:</strong> {filme.diretor}</p>
        <p><strong>Estúdio:</strong> {filme.estudio}</p>
        <p className="mt-4">{filme.sinopse}</p>
      </div>
    </div>
  );
}
