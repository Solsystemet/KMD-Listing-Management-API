import styles from "./Navbar.module.css";
import imgKMD from "../../assets/imgKMD.svg";
import { NavButton } from "../buttons/Buttons";
import { Link } from "@tanstack/react-router";

type NavbarChild = {
   url: string;
   label: string;
};

type NavbarProps = {
   children: NavbarChild[];
};

export function Navbar({ children }: NavbarProps) {
   return (
      <nav>
         <div className={styles.contentContainer}>
            <Link to={"/listing/$listingId"} params={{ listingId: "index" }}>
               <img src={imgKMD} alt="Logo" />
            </Link>
            {children.map((child, index) => (
               <div key={index} className={styles.menuButtonContainer}>
                  <NavButton fontSize={"1rem"} color={"white"} href={child.url}>
                     {child.label}
                  </NavButton>
               </div>
            ))}
         </div>
      </nav>
   );
}
