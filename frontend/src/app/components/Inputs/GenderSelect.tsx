'use client'

interface Props {
  value: string[];
  onChange: (genres: string[]) => void;
}

const GENRES = [
  "Ação",
  "Comédia",
  "Drama",
  "Romance",
  "Terror",
  "Suspense",
  "Ficção Científica",
  "Animação",
  "Documentário",
  "Fantasia",
  "Infantil",
];

export default function GenderSelect({value, onChange}: Props) {
  function addGenre(genre: string) {
    if(!value.includes(genre)) {
      onChange([...value, genre]);
    }
  }

  function removeGenre(genre: string) {
    onChange(value.filter(g => g !== genre));
  }

  return (
    <div className="flex flex-col gap-2 w-full max-w-md">
      <label className="text-[rgba(182,80,250,1)] font-semibold">
        Gêneros
      </label>

      <select
      aria-label="Adicionar"
      onChange={(e) => addGenre(e.target.value)}
      value=""
      className="bg-fuchsia-100 px-3 py-2 rounded-lg text-black"
      >
        <option value="">Adicionar Gênero</option>
        {GENRES.map((genre) =>(
          <option key={genre} value={genre}>
            {genre}
          </option>
        ))}
      </select>

      <div className="bg-fuchsia-100 px-3 py-2 rounded-lg text-black">
        {value.map((genre) => (
          <span key={genre} className="bg-fuchsia-100 px-3 py-2 rounded-lg text-black">
            {genre}
            <button type="button" onClick={() => removeGenre(genre)} className="font-bold hover:text-red-600">
              [x]
            </button>
          </span>
        ))}
      </div>
    </div>
  )
}