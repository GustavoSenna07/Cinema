"use client"

import HeaderAdmin from "./HeaderAdmin"
import HeaderUser from "./HeaderUser"

type HeaderProps = {
  role?: "user" | "admin";
};

export default function Header({role = "user"}:HeaderProps) {
  return (
    <header className="bg-neutral-700 w-screen h-min-[10] flex flex-row fixed top-0 items-center justify-between z-50">

      <h1 className="text-[rgba(182,80,250,1)] font-bold text-shadow-lg text-4xl p-2">
        Cinema das Lendas
      </h1>

      <div className="items-end">
        {role === "admin" ? <HeaderAdmin /> : <HeaderUser />} {/* Linha de condição */}
      </div>

    </header>
  )
}
