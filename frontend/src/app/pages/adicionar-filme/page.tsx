'use client';

import Input from "@/app/components/Inputs/Input"
import Button from "@/app/components/Inputs/Button"
import GenderSelect from "@/app/components/Inputs/GenderSelect";
import { useState } from "react";

export default function AdicionarFilme() {
  const [releaseDate, setReleaseDate] = useState("");
  const [rating, setRating] = useState("");
  const [genres, setGenres] = useState<string[]>([]);

  return (
    <div className="bg-neutral-800 flex justify-center items-center p-2 box-border w-screen h-screen">
      <div className="bg-neutral-700 p-2 flex justify-center items-center w-full h-full rounded-2xl flex-row ">
        <div className="w-1/2 flex flex-col items-center justify-center gap-4 pl-20">
          <Input label="Titulo" type="text" placeHolder="Titulo"/>
          <Input label="Diretor" type="text" placeHolder="Diretor do Filme"/>
          <Input label="Estudio" type="text" placeHolder="Estudio do Filme"/>
          <Input label="Sinopse" type="text" placeHolder="Sinopse"/>
          <Input label="Elenco" type="text" placeHolder="Elenco do Filme"/>
        </div>
        <div className="w-1/2 flex flex-col items-center justify-center gap-4 pr-20">
          <Input
            label="Data de Lançamento"
            type="date"
            value={releaseDate}
            onChange={(value) => setReleaseDate(value as string)}
          />
          <Input label="Duração " type="duration"/>
          <Input label="Classificação Indicativa" type="rating" value={rating} onChange={(value) => setRating(value as string)}/>
          <GenderSelect value={genres} onChange={setGenres}/>
        </div>
      </div>
    </div>
  )
}