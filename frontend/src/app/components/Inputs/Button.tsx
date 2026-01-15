"use client";
import { ReactNode } from "react";
import Link from "next/link";

type ButtonVariant = "primary" | "secundary" | "headerbt";

interface ButtonProps {
  children: ReactNode;
  variant?: ButtonVariant;
  type?: "button" | "submit";
  href?: string;
}

export default function Button({
  children,
  variant = "primary",
  type = "button",
  href,
}: ButtonProps) {
  const baseStyle =
    "shadow-md rounded-[15] font-semibold text-2xl flex justify-center items-center text-shadow-lg";

  const variants = {
    primary:
      "bg-[rgba(182,80,250,1)] text-black hover:bg-purple-400 active:bg-purple-500 w-[350px] h-[50px]",
    secundary: "bg-gray-300 text-black w-[350px] h-[50px]",
    headerbt:
      "bg-[rgba(182,80,250,1)] w-[200px] h-[30px] text-black hover:bg-purple-400 active:bg-purple-500",
  };

  const className = `${baseStyle} ${variants[variant]}`;

  if (href) {
    return (
      <Link href={href} className={className}>
        {children}
      </Link>
    );
  }

  return (
    <button type={type} className={className}>
      {children}
    </button>
  );
}
