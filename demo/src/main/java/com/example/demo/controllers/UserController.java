package com.example.demo.controllers;

import java.util.List;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.demo.Models.Pepe;
import com.example.demo.Models.Sarasa;
import com.example.demo.Services.UserService;

import jakarta.validation.Valid;

@RestController
@RequestMapping("/tttt")
public class UserController {

    private final UserService userService;

    public UserController(UserService userService) {
        this.userService = userService;
    }

    @SuppressWarnings("rawtypes")
    @PostMapping()
    public ResponseEntity addUser(@Valid @RequestBody  Pepe user) {
            userService.saveUser(user);
            return ResponseEntity.noContent().build();
    }

    @SuppressWarnings("rawtypes")
    @GetMapping()
    public ResponseEntity showSignUpForm() {
        return ResponseEntity.noContent().build();
    }

    @GetMapping("/test")
    public ResponseEntity<List<Sarasa>> getCachedUsers(){
        return ResponseEntity.ok(this.userService.getSarasa());
    }

}
