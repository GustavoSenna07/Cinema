'use client';

import Input from "@/app/components/Inputs/Input"
import Button from "@/app/components/Inputs/Button"
import GenderSelect from "@/app/components/Inputs/GenderSelect";
import ImageUpload from "@/app/components/Inputs/ImageUpload";
import { useState } from "react";
import { Dice1 } from "lucide-react";

export default function AdicionarFilme() {

  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [success, setSuccess] = useState(false);

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();

    const data = new FormData();

    data.append("Titulo", formData.title);
    data.append("Diretor", formData.director);
    data.append("Estudio", formData.studio);
    data.append("Sinopse", formData.synopsis);
    data.append("Elenco", formData.cast);
    data.append("Classificacao", formData.rating);
    data.append("Genero", formData.genres.join(","));
    data.append("DuracaoMinutos", formData.durationMovie.toString());
    data.append("DataLancamento", formData.releaseDate);

    if (image) {
      data.append("Imagem", image);
    }

    const response = await fetch("http://localhost:5006/api/filmes", {
      method: "POST",
      body: data,
    });

    if (!response.ok) {
      console.error("Erro ao salvar filme");
      return;
    }

    const result = await response.json();
    console.log("Filme salvo:", result);
  }


  const [image, setImage] = useState<File | null>(null);
  const [preview, setPreview] = useState<string | null>(null);

  const [formData, setFormData] = useState({
    title: "",
    director: "",
    studio: "",
    synopsis: "",
    cast: "",
    releaseDate: "",
    durationMovie: 0,
    rating: "",
    genres: [] as string[],
  })

  async function createMovie(data: FormData) {
    const response = await fetch("http://localhost:3000/pages/filmes", {
      method: "POST",
      body: data,
    });
    
    if(!response.ok) {
      const error = await response.json();
      throw new Error(error.detail || "Erro ao cadastrar o Filme");
    }

    return response.json();
  }

  return (
    <form onSubmit={handleSubmit}>
      <div className="bg-neutral-800 flex justify-center items-center p-2 box-border w-screen h-screen">
        <div className="bg-neutral-700 p-2 flex justify-center items-center w-full h-full rounded-2xl flex-row ">
            <div className="w-1/2 flex flex-col items-center justify-center gap-4 pl-20">
              <Input label="Titulo" type="text" placeHolder="Titulo" value={formData.title} 
                onChange={(value) => setFormData((prev) => ({...prev, title: value as string}))} required/>

              <Input label="Diretor" type="text" placeHolder="Diretor do Filme" value={formData.director} 
                onChange={(value) => setFormData((prev) => ({...prev, director: value as string}))}/>

              <Input label="Estudio" type="text" placeHolder="Estudio do Filme" value={formData.studio}
                onChange={(value) => setFormData((prev) => ({...prev, studio: value as string}))}/>

              <Input label="Sinopse" type="text" placeHolder="Sinopse" value={formData.synopsis}
                onChange={(value) => setFormData((prev) => ({...prev, synopsis: value as string}))}/>

              <Input label="Elenco" type="text" placeHolder="Elenco do Filme" value={formData.cast}
                onChange={(value) => setFormData((prev) => ({...prev, cast: value as string}))}/>

              <Input label="Duração " type="duration" 
                onChange={(value) => setFormData((prev) => ({...prev, durationMovie: value as number}))}/>

              <Input label="Classificação Indicativa" type="rating" value={formData.rating} 
                onChange={(value) => setFormData((prev) => ({...prev, rating: value as string}))}/>
            </div>
            <div className="w-1/2 flex flex-col items-center justify-center gap-4 pr-20">
              <Input
                label="Data de Lançamento"
                type="date"
                value={formData.releaseDate}
                onChange={(value) => setFormData((prev) => ({...prev, releaseDate: value as string}))}
              />

              <GenderSelect value={formData.genres} onChange={(genres) => setFormData((prev) => ({...prev, genres}))}/>

              <ImageUpload image={image} preview={preview} onChange={(file, previewUrl) => {
                setImage(file);
                setPreview(previewUrl);
              }}/>

              {error && (
                <p className="text-red-500 text-sm">{error}</p>
              )}

              {success && (
                <p className="text-green-500 text-sm">
                  Filme cadastrado com sucesso!
                </p>
              )}

              <Button type="submit" variant="headerbt">
                {loading ? "Salvando..." : "Salvar"}
              </Button>
            </div>
        </div>
      </div>
    </form>
  )
}