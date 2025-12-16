"use client";

import { useRouter } from "next/navigation";
import Button from "./components/Button";

export default function Home() {
  const Router = useRouter();
  return (
    <div className="bg-[rgba(52,52,52,1)] w-screen h-screen justify-center items-center flex flex-col ">
      <div className="flex justify-center items-center mb-40">
        <h1 className="text-8xl text-[rgba(182,80,250,1)]">Cinema das Lendas</h1>
      </div>

      <div className="flex flex-col gap-10">
        <Button />
        <Button />
      </div>
    </div>
  );
}
