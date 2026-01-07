import FooterAdmin from "./FooterAdmin";
import FooterUser from "./FooterUser";

type FooterProps = {
  role?: "user" | "admin"
}

export default function Footer({role}:FooterProps) {
  return (
    <footer className="fixed bottom-0 bg-neutral-700 w-full h-min-[10]">
      {role === "admin" ? <FooterAdmin /> : <FooterUser />}
    </footer>
  )
}