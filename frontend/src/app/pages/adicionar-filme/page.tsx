'use client';

import Input from "@/app/components/Input"
import Button from "@/app/components/Button"
import { useState } from "react";

export default function AdicionarFilme() {
  const [releaseDate, setReleaseDate] = useState("");
  return (
    <div className="bg-neutral-800 flex justify-center items-center p-2 box-border w-screen h-screen">
      <div className="bg-neutral-700 p-2 flex justify-center items-center w-full h-full rounded-2xl flex-col gap-2">
        <div>
          <Input label="Titulo" type="text" placeHolder="Titulo"/>
          <Input label="Diretor" type="text" placeHolder="Diretor do Filme"/>
          <Input label="Estudio" type="text" placeHolder="Estudio do Filme"/>
          <Input label="Sinopse" type="text" placeHolder="Sinopse"/>
          <Input label="Elenco" type="text" placeHolder="Elenco do Filme"/>
          <Input label="Data de Lançamento" type="date" value={releaseDate} onChange={(e) => setReleaseDate(e.target.value)}/>
        </div>
      </div>
    </div>
  )
}