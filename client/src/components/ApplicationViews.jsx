import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { ItemList } from "./Items/ItemList";
import { ItemForm } from "./Items/ItemForm";
import { FloorList } from "./Floors/FloorList";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
      <Route index element={<FloorList />} />
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="/items">
        <Route index element={
          <AuthorizedRoute loggedInUser={loggedInUser}>
            <ItemList loggedInUser={loggedInUser} />
          </AuthorizedRoute>
        }/>
        <Route path=":itemId" element={
          <AuthorizedRoute loggedInUser={loggedInUser}>
            <ItemForm loggedInUser={loggedInUser} />
          </AuthorizedRoute>
        }/>
      </Route>
      <Route path="/createitem">
        <Route index element={
          <AuthorizedRoute loggedInUser={loggedInUser}>
            <ItemForm loggedInUser={loggedInUser} />
          </AuthorizedRoute>
        }/>
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
