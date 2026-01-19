'use client';

import { useEffect, useState } from "react";
import Header from "@/app/components/Header/Header";
import Footer from "@/app/components/Footer/Footer";
import { api } from "@/app/services/api";
import { Filme } from "@/app/types/Filme";
import { CardFilme } from "@/app/components/CardFilme";

export default function Filmes() {
  const [filmes, setFilmes] = useState<Filme[]>([]);

  useEffect(() => {
    api.get<Filme[]>("/filmes").then(response => {
      setFilmes(response.data);
    });
  }, []);

  return (
    <div className="bg-neutral-800 min-h-screen overflow-x-hidden">
      <Header role="admin" />

      <div className="py-20">
        <h1 className="text-2xl font-bold mb-8 px-8">
          Filmes em Cartaz
        </h1>

        <div className="grid grid-cols-1 md:grid-cols-3 gap-10 max-w-7xl mx-auto">
          {filmes.map(filme => (
            <CardFilme key={filme.id} filme={filme} />
          ))}
        </div>
      </div>

      <Footer role="admin" />
    </div>
  );
}

