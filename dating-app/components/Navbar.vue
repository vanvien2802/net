<template>
    <nav class="navbar bg-primary">
      <div class="container-fluid">
        <a href="/" class="navbar-brand">Navbar</a>
        <form class="d-flex" v-if="!tokenCookie">
          <input
            v-model="loginInfo.username"
            class="form-control me-2"
            type="text"
            placeholder="Email"
          />
          <input
            v-model="loginInfo.password"
            class="form-control me-2"
            type="password"
            placeholder="Password"
          />
          <button class="btn btn-success" type="button" @click="login">
            Login
          </button>
        </form>
        <button
          v-else
          class="btn btn-success"
          type="button"
          @click="tokenCookie = null"
        >
          Logout
        </button>
      </div>
    </nav>
  </template>
  <script lang="ts" setup>
  import type { LoginInfor } from "../types";
  const tokenCookie = useCookie("tokenCookie");
  const loginInfo = ref<LoginInfor>({ username: "", password: "" });
  const login = async () => {
    if (loginInfo.value.username && loginInfo.value.password) {
      const { data } = await useFetch<string>(
        "http://localhost:5216/api/auth/login",
        {
          method: "POST",
          body: loginInfo.value,
        }
      );
      if (data) {
        tokenCookie.value = data.value;
      }
    }
  };
  </script>