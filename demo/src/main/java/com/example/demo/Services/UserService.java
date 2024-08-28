package com.example.demo.Services;

import java.util.List;
import java.util.ArrayList;
import java.util.concurrent.CompletableFuture;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.scheduling.annotation.Async;
import org.springframework.stereotype.Service;

import com.example.demo.Models.Pepe;
import com.example.demo.Models.Sarasa;
import com.example.demo.repositories.UserRepository;

import jakarta.annotation.PostConstruct;

@Service
public class UserService {
    @Autowired
    private UserRepository userRepository;

    private List<Sarasa> lista;

    @PostConstruct
    public void init(){
        this.lista = new ArrayList<>();
        this.lista.add(new Sarasa("Sarasa", "email"));
        this.lista.add(new Sarasa("Sarasa", "email"));
        this.lista.add(new Sarasa("Sarasa", "email"));
        this.lista.add(new Sarasa("Sarasa", "email"));
        this.lista.add(new Sarasa("Sarasa", "email"));
    }

    @Async
    public CompletableFuture<Pepe> saveUser(Pepe pepe) {
        Pepe newPepe = userRepository.save(pepe);
        return CompletableFuture.completedFuture(newPepe);
    }

    public List<Sarasa> getSarasa(){
        return this.lista;
    }
}
