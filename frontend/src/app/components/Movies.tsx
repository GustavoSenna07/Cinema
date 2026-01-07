type MoviesVariant = "category" | "poster";

interface MoviesProps {
  variant: MoviesVariant;
  titleMovie: string;
  imageUrlMovie: string;
}

export default function Movies({variant = "category", titleMovie, imageUrlMovie}: MoviesProps) {
  const basicStyle = "w-[200px] cursor-pointer hover:scale-102 transition flex justify-center flex-col items-center p-2 overflow-x-auto overflow-y-hidden h-[270px] flex-shrink-0";

  const variants = {
    category: "",
    poster: ""
  }
  return (
    <div className={`${basicStyle} ${variants[variant]}`}>
      <img src={imageUrlMovie} alt={titleMovie} className="rounded-[6] w-full h-full object-cover"/>
      {/*<p className="font-bold text-[rgba(182,80,250,1)] text-shadow-lg text-[15px] p-2 text-sm text-center overflow-hidden">{titleMovie}</p>*/}
    </div>
  )
}