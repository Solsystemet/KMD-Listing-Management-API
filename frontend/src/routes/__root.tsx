import { createRootRoute, Outlet } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/router-devtools";
import { Navbar } from "../components/navbar/Navbar";
import "./../index.css";
import { DisplayListing } from "../components/displayListing/DisplayListing";
const mockListingData = {
  dataController: {
    name: "KMD A/S",
    cvr: "26911745",
    address: "Lautrupparken 40-42, 2750 Ballerup",
    phoneNo: "+45 44 60 10 00",
    mail: "kmd@kmd.dk",
  },
  dataProcessor: {
    name: "Tech Solutions ApS",
    cvr: "12345678",
    address: "Innovationsvej 2, 2300 København",
    phoneNo: "+45 70 12 34 56",
    mail: "contact@techsolutions.dk",
  },
  dataControllerRepresentative: {
    name: "John Doe",
    role: "Data Protection Officer",
    address: "Lautrupparken 40-42, 2750 Ballerup",
    phoneNo: "+45 44 60 11 11",
    mail: "dpo@kmd.dk",
  },
  dataProcessorRepresentative: {
    name: "Jane Smith",
    role: "Privacy Manager",
    address: "Innovationsvej 2, 2300 København",
    phoneNo: "+45 70 12 34 57",
    mail: "privacy@techsolutions.dk",
  },
  dataSubProcessors: [
    {
      name: "Cloud Storage A/S",
      cvr: "87654321",
      address: "Skyvej 1, 8000 Århus",
      treatment: "Cloud storage and backup services",
      directSubProcessor: true,
      transferReason: "Primary data storage provider with EU-based servers",
    },
    {
      name: "Security Systems ApS",
      cvr: "98765432",
      address: "Sikkerhedsgade 5, 5000 Odense",
      treatment: "Security monitoring and encryption services",
      directSubProcessor: false,
      transferReason: "Security infrastructure maintenance",
    },
  ],
  informationDescription:
    "Dette system behandler personoplysninger i forbindelse med administration af medarbejderdata. Dette inkluderer:\n- Personlige informationer\n- Kontaktoplysninger\n- Ansættelsesdetaljer\n- Løninformationer",
  securityMeasures:
    "Følgende sikkerhedsforanstaltninger er implementeret:\n\n1. Kryptering af data i hvile og under transport\n2. To-faktor autentificering for alle brugere\n3. Regelmæssig sikkerhedsaudit\n4. Automatisk logning af dataadgang\n5. Fysisk sikkerhed i datacentre",
};

export const Route = createRootRoute({
  component: () => (
    <>
      <Navbar children={[{ url: "/upload-page", label: "Create Listing" }]} />
      <Outlet />
      <TanStackRouterDevtools />
      <DisplayListing listingData={mockListingData} />
    </>
  ),
});
