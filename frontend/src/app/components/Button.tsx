"use client";
import { ReactNode } from "react";
import Link from "next/link";

type ButtonVariant = "primary" | "secundary" | "headerbt";
//Define a estrutura de dados que um botão pode receber
interface ButtonProps { // 
  children: ReactNode;
  href: string;
  variant: ButtonVariant;
}
// children = valor que ficara visivel no button
// variant = variante do botão que vai ser usada
export default function Button({children, href, variant = "primary"}: ButtonProps) {
  const baseStyle = "shadow-md rounded-[15] font-semibold text-2xl flex justify-center items-center text-shadow-lg"; // estilo padrão que vão ter em todos os botões

  const variants = {
    primary: "bg-[rgba(182,80,250,1)] text-black hover:bg-purple-400 active:bg-purple-500 w-[350px] h-[50px]",
    secundary: "bg-gray-300 text-black w-[350px] h-[50px]",
    headerbt: "bg-[rgba(182,80,250,1)] w-[200px] h-[30px] text-black hover:bg-purple-400 active:bg-purple-500"
  }
  return (
    <Link href={href} className={`${baseStyle} ${variants[variant]}`}> 
      {children}
    </Link>
  )
}